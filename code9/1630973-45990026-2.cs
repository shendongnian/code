    var productInfoViewModelCollection =
        from x in db.MinimumProductInfo
        join pnote in db.ProductNotes on x.PRIMARYKEY equals pnote.PRIMARYKEY
        join cnote in db.ProductNotes on x.PRIMARYKEY equals cnote.PRIMARYKEY
        let pnoteMaxDate = 
            (from inner_pnote in db.ProductNotes 
            where x.PRIMARYKEY == inner_pnote.PRIMARYKEY
                && inner_pnote.NoteTypeFlag == "p"
            select inner_pnote.NoteDate).Max()
        let cnoteMaxDate = 
            (from inner_cnote in db.ProductNotes 
            where x.PRIMARYKEY == inner_cnote.PRIMARYKEY
                && inner_cnote.NoteTypeFlag == "c"
            select inner_cnote.NoteDate).Max()
        where  pnote.NoteTypeFlag == "p" && pnote.NoteDate == pnoteMaxDate 
            && cnote.NoteTypeFlag == "c" && cnote.NoteDate == cnoteMaxDate
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
