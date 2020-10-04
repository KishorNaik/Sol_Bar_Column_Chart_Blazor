/// <reference path="../lib/jquery-3.5.1.min.js" />
/// <reference path="../lib/jquery.simple-bar-graph.js" />

function setBarChart(elementRef, chartInfoJson) {
    // Display Element Ref Id
    console.log("Bar Chart Ref Id : ", elementRef);

    // Display Bar Chart Json Data
    console.log("Bar Chart Json Data : ", chartInfoJson);

    // Display Bar Chart Model Object
    var chartInfo = JSON.parse(chartInfoJson);
    console.log("Bar Chart Model Data : ", chartInfo);

    // Display Bar Chart Key Value Data
    var chartData = JSON.parse(chartInfo.Data);
    console.log("Bar Chart Key Value Data : ", chartData);

    $(elementRef).simpleBarGraph({
        data: chartData,
        rowsCount: chartInfo.RowsCount,
        height: chartInfo.Height,
        rowCaptionsWidth: chartInfo.RowCaptionsWidth,
        barsColor: chartInfo.BarsColor,
        delay: chartInfo.AnimationDelay
    });
}