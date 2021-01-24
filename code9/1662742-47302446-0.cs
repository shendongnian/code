     [HttpPost]
        public ActionResult Index (updown viewModel)
        {    
            using (var dbContextTransaction = db.BeginTransaction()) 
            { 
               var year =  DateTime.Now.Year("D4");
               var lastPO = db.updowns
                   .Where(x => (x=> x.tangal.Substring(22 /* is it 22 ? */).Equals(year))
                   .OrderByDescending(x => x.tanggal)
                   .FirstOrDefault()?.tanggal.Substring(5, 5) ?? "00000";
    
               item.tanggal = "EMOC-" + (lastPO+1).ToString("00000") 
                           + "-S2/" + DateTime.Now.Year;
        
               db.updowns.Add(item);
               db.SaveChanges();
           }
        }
