    @(Html.Kendo().TabStrip().Name("myTabStrip")
        .Items(tabs =>
        {
            tabs.Add().Text("T1").LoadContentFrom("Tab1", "Controller", new { Id = Model.Id });
            tabs.Add().Text("T2").LoadContentFrom("Tab2", "Controller", new { Id = Model.Id });
            tabs.Add().Text("T3").LoadContentFrom("Tab3", "Controller", new { Id = Model.Id });
        })
        .Events(e => e
            .ContentLoad("onContentLoad")
            .Select("onTabSelect")
        )
    )
