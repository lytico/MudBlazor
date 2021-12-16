using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;

namespace MudBlazor
{
    public partial class MudTd : MudComponentBase
    {

        protected string Classname =>
        new CssBuilder("mud-table-cell")
            .AddClass("mud-table-cell-hide", HideSmall)
            .AddClass("mud-table-cell-gutters", DisableGutters)
            .AddClass(Class)
        .Build();

        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public string DataLabel { get; set; }

        /// <summary>
        /// Hide cell when breakpoint is smaller than the defined value in table.
        /// </summary>
        [Parameter] public bool HideSmall { get; set; }
        
        /// <summary>
        /// If true, the left and right padding is removed from childcontent.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.Table.Appearance)]
        public bool DisableGutters { get; set; }
    }
}
