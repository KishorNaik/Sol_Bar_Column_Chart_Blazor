using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarChart
{
    public partial class BarChartComponent
    {
        #region Public Parameter Property

        [Parameter]
        public List<BarChartResultSet> Data { get; set; }

        [Parameter]
        public int RowsCount { get; set; }

        [Parameter]
        public String Height { get; set; }

        [Parameter]
        public String RowCaptionsWidth { get; set; }

        [Parameter]
        public String BarsColor { get; set; }

        [Parameter]
        public int AnimationDelay { get; set; }

        #endregion Public Parameter Property

        #region Private Property

        private ElementReference ElementReferenceId { get; set; }

        [Inject]
        private IJSRuntime JSRuntimeObj { get; set; }

        #endregion Private Property

        #region Private Method

        private Task<string> BindBarChartJsAsync()
        {
            return Task.Run(() =>
            {
                var barChartJsModel = new BarChartJsModel()
                {
                    Data = JsonConvert.SerializeObject(this.Data),
                    Height = this.Height,
                    RowsCount = this.RowsCount,
                    RowCaptionsWidth = this.RowCaptionsWidth,
                    BarsColor = this.BarsColor,
                    AnimationDelay = this.AnimationDelay
                };

                return JsonConvert.SerializeObject(barChartJsModel);
            });
        }

        #endregion Private Method

        #region Public Method

        public async Task SetBarChartAsync()
        {
            await ElementReferenceId.CallBarChartJs(JSRuntimeObj, await this.BindBarChartJsAsync());
            base.StateHasChanged();
        }

        #endregion Public Method
    }
}