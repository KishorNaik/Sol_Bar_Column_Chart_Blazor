using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarChart
{
    internal static class BarChartExtension
    {
        internal static async Task CallBarChartJs(this ElementReference elementReference, IJSRuntime jSRuntime, string barChartJsData)
        {
            await jSRuntime.InvokeVoidAsync(identifier: "setBarChart", elementReference, barChartJsData);
        }
    }
}