    var productInfoViewModelCollection =
        from x in db.MinimumProductInfo
        join pnote in db.ProductNotes on x.PRIMARYKEY equals pnote.PRIMARYKEY
        join cnote in db.ProductNotes on x.PRIMARYKEY equals cnote.PRIMARYKEY
        where  pnote.NoteTypeFlag == "p" && pnote.NoteDate.Max() 
            && cnote.NoteTypeFlag == "c" && cnote.NoteDate.Max() 
        select new ProductInfoWithNoteList { 
            MinimumProductInfoID = x.MinimumProductInfoID, 
            ItemCode = x.ItemCode, 
            MinimumOnHandQuantity = x.MinimumOnHandQuantity, 
            MaximumOHandQuantity = x.MaximumOHandQuantity, 
            MinimumOrderQuantity = x.MinimumOrderQuantity, 
            LeadTimeInWeeks = x.LeadTimeInWeeks,
            // LatestCNote = cnote, //(Add these to your ViewModel class or make a new ViewModel)
            // LatestPNote = pnote
         });
