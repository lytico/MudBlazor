using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;

namespace MudBlazor;

#nullable enable

/// <summary>
/// A header cell which labels a column of data for a <see cref="MudTable{T}"/>.
/// </summary>
public partial class MudTh : MudComponentBase
{
    protected string Classname => new CssBuilder("mud-table-cell")
        .AddClass("mud-table-cell-gutters", DisableGutters)
        .AddClass(Class)
        .Build();

        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// If true, the left and right padding is removed from childcontent.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.Table.Appearance)]
        public bool DisableGutters { get; set; }
    }
}
