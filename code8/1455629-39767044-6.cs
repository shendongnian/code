     TCDEntities db = new TCDEntities();
    
        public ActionResult Index()
        {
            CrossViewModel vm = new CrossViewModel();
    
            vm.Crosses = db.Crosses.Take(1).ToList();
    
            Cross cross = db.Crosses.FirstOrDefault();
    
            // List<C400_Article_Search_Tree_Allocation> C400 = db.C400_Article_Search_Tree_Allocation.Where(k => k.ArtNr == cross.Article_From && k.DLNr == cross.Supplier_From && k.KritNr == 2).ToList();
    
            vm.Refnr = db.C203_Reference_Numbers.Where(r => r.ArtNr == cross.Article_From && r.DLNr == cross.Supplier_From).ToList();
            vm.Refnr2 = db.C203_Reference_Numbers.Where(r => r.ArtNr == cross.Article_To && r.DLNr == cross.Supplier_To).ToList();
    
            // C400_Article_Search_Tree_Allocation article = db.C400_Article_Search_Tree_Allocation.Where(k => k.ArtNr == cross.Article_From && k.DLNr == cross.Supplier_From && k.KritNr == 2);
    
            vm.C400 = db.C400_Article_Search_Tree_Allocation.Where(k => k.ArtNr == cross.Article_From && k.DLNr == cross.Supplier_From && k.KritNr == 2).ToList();
            vm.C400_2 = db.C400_Article_Search_Tree_Allocation.Where(k => k.ArtNr == cross.Article_To && k.DLNr == cross.Supplier_To && k.KritNr == 2).ToList();
    
            //var C400Ktype = db.C400_Article_Search_Tree_Allocation.Where(k => k.ArtNr == cross.Article_From && k.DLNr == cross.Supplier_From && k.KritNr == 2).ToList();
    
            return View(vm);
        }
