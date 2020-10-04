using System;
using System.Collections.Generic;
using System.Text;

namespace BarChart
{
    internal class BarChartJsModel
    {
        public string Data { get; set; }

        public int RowsCount { get; set; }

        public string Height { get; set; }

        public string RowCaptionsWidth { get; set; }

        public string BarsColor { get; set; }

        public int AnimationDelay { get; set; }
    }
}