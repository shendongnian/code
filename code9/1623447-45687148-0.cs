    var series = (Excel.SeriesCollection)chartPage.SeriesCollection();
    series.Item(1).Points(1).Interior.ColorIndex = 3; //Red
    series.Item(1).Points(2).Interior.ColorIndex = 4; //Green
    series.Item(1).Points(3).Interior.ColorIndex = 5; //Blue
    series.Item(1).Points(4).Interior.ColorIndex = 6; //Yellow
    series.Item(1).Points(5).Interior.ColorIndex = 7; //Magenta
