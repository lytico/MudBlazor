

using Microsoft.AspNetCore.Components;

using MudBlazor.Utilities;

namespace MudBlazor
{
    public partial class MudTh : MudComponentBase
    {
        protected string Classname => new CssBuilder("mud-table-cell")
            .AddClass("mud-table-cell-gutters", DisableGutters)
            .AddClass(Class).Build();

        [Parameter] public RenderFragment ChildContent { get; set; }
        
        /// <summary>
        /// If true, the left and right padding is removed from childcontent.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.Table.Appearance)]
        public bool DisableGutters { get; set; }
    }
}

