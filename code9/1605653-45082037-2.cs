    private traderEntities db = new traderEntities();
    BlobProfileImageServices _blobServices = new BlobProfileImageServices();
        public ActionResult Index(string usernameCookie)
            {
    
                var viewModel = from u in db.tradesusers
                                join j in db.jobs on u.id equals j.jobbyuserid
                                where u.email.Equals(usernameCookie) 
                                select new JoinUsersandJobsModel { tradesusers = u, jobs = j, uploadedfiles = pic };
    
                return View(viewModel);
               
            }
