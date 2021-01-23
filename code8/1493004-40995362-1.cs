    public IActionResult Invoice(int id)
    {
        var query = from d in _dayRepo.GetAll()
                                join job in _jobRepo.GetAll() on d.JobId equals job.JobId
                                select new { Date=d.Date, LotNum= job.job , Street =job.Street , Suburb =job.Suburb , Hours =d.Hours };
        
        IEnumerable<InvoiceViewModel> viewModel = query.Select(c => new  InvoiceViewModel() 
       { 
         Date=query.Date,
         LotNum=query.LotNum,
         Street=query.Street,
         Suburb=query.Suburb,
         Hours=query.Hours 
       });
        
         return View(viewModel);
    }
