    @(Html.Kendo().Chart<ChartsModel>()
             .HtmlAttributes(new { style = "width:100%;height:263px" })
      .Name("InvoiceChart")
      .DataSource(dataSource => dataSource
      .Read(read => read.Action("_BindInvoiceChart", "yourCOntrollerName")) // Specify the action method and controller name
      )
      .Name("chart")
        .Theme("blueOpal")
        .HtmlAttributes(new { style = "height: 400px;" })
        .Title("Site Visitors Stats /thousands/")
        .Legend(legend => legend
            .Position(ChartLegendPosition.Bottom)
        )
        .SeriesDefaults(seriesDefaults => seriesDefaults
            .Column().Stack(true)
        )
        .Series(series =>
        {
			 series.Column(d => d.invoices).Tooltip(tooltip => tooltip.Visible(true)).Name("Week Totals");                    
         // series.Column(model => ChartDataHelper.GetWeekTotals(model.Invoices)).Name("Week Totals"); // fails
          //series.Column(new double[] { 52000, 34000, 23000, 48000, 67000, 83000 }).Name("Unique visitors"); // works
        })
        .CategoryAxis(axis => axis
            .Categories("Jan", "Feb", "Mar", "Apr", "May", "Jun")
            .MajorGridLines(lines => lines.Visible(false))
        )
        .ValueAxis(axis => axis
            .Numeric()
            .Line(line => line.Visible(false))
        )
        .Tooltip(tooltip => tooltip
            .Visible(true)
            .Format("{0}")
        ))
