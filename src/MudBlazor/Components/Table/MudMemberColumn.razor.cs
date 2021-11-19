using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MudBlazor
{
    /// <summary>
    /// Binds an object's property to a column by its property name 
    /// </summary>
    public partial class MudMemberColumn<T, M> : MudBaseColumn
    {
        M Value
        {
            get => GetValue(Item);
            set
            {
                if (!EqualityComparer<M>.Default.Equals(value, Value))
                {
                    SetValue(Item, value);
                    ValueChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter] public EventCallback<M> ValueChanged { get; set; }

        [Parameter]
        public M FooterValue
        {
            get { return _footerValue; }
            set
            {
                _footerValue = value;
                _footerValueAvailable = true;
            }
        }

        private M _footerValue;
        private bool _footerValueAvailable = false;


        /// <summary>
        /// Used if no FooterValue is available
        /// </summary>
        [Parameter] public string FooterText { get; set; }

        /// <summary>
        /// Specifies which string format should be used.
        /// </summary>
        [Parameter] public string DataFormatString { get; set; }

        [Parameter] public bool ReadOnly { get; set; }

        private string GetFormattedString(M item)
        {
            if (DataFormatString != null)
            {
                return string.Format(DataFormatString, item);
            }
            else
            {
                return item?.ToString();
            }
        }

        [Parameter]
        public T Item { get; set; }

        /// <summary>
        /// Field which this column is for<br />
        /// Required when Sortable = true<br />
        /// Required when Filterable = true
        /// </summary>
        [Parameter]
        public Expression<Func<T, M>> Member { get; set; }

        private Func<T, M> _getter;

        public M GetValue(T item)
        {
            if (item == null || Member == null) return default;

            _getter ??= Member.Compile();

            try
            {
                var value = _getter.Invoke(item);

                return value;
            }
            catch (NullReferenceException) { }

            return default;
        }

        public void SetValue(T item, M value) { }

        protected override Task OnParametersSetAsync()
        {
            HeaderText ??= Member.GetDisplayName();

            return base.OnParametersSetAsync();
        }
    }

    public static class MemberColumnExtensions
    {
        public static string GetDisplayName<T, M>(this Expression<Func<T, M>> e)
        {
            if (e == null) return null;

            if (e.MemberInfo() is PropertyInfo p)
            {
                if (p
                    .GetCustomAttributes(typeof(DisplayAttribute), false)
                    .FirstOrDefault() is DisplayAttribute displayAttribute)
                {
                    return displayAttribute.Name ?? p.Name;
                }

                return p.Name;
            }

            return null;
        }

        public static MemberInfo MemberInfo<T, TMember>(this Expression<Func<T, TMember>> exp)
        {
            if (exp.Body is MemberExpression member) return member.Member;
            if (exp.Body is MethodCallExpression method) return method.Method;
            throw new ArgumentException($"{exp.ToString()} is not a MemberExpression");
        }
    }
}
