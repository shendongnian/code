        columns.Add(x => x.ItemPrice)
            .Titled("Price")
            .Encoded(false)
            .Sortable(true)
            .Filterable(false)
            .RenderedAs(c => string.Format("{0:C}", c.ItemPrice));
