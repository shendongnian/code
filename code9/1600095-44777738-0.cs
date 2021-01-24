    using (MyDatabase db = new MyDatabase())
    {
        var sale = db.Set<Sale>();
        var saleComment = new SalesComment{Comment="Hello"};
        var saleToAdd = new Sale
        {
            Foo = "Test",
            Bar = "Test",
            Comments.Add(saleComment)
        });
        sale.Add(saleToAdd);
        db.SaveChanges();
        
        // After saving changes, these 2 values will be populated and are equal
        var saleID = saleToAdd.Id;
        var saleCommentSaleId = saleComment.saleId;
    }
