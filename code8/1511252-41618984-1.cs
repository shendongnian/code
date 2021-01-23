    public ActionResult Index12()  //this Method name can change
        {
            using (BreazEntities2 e = new BreazEntities2())  //you will use the dbcontext name you have
            {
                try
                {
                    var _job = e.Jobs.Find(1);
                    if (_job.JobRelateds.Any())
                    {
                        foreach (var relatedJob in _job.JobRelateds.ToList())
                        {
                            Job addToJob = new Job();
                            //no relateds for this
                            addToJob.JobDescription = "From related to Job->" + relatedJob.RelatedJobDescription;
                            e.Jobs.Add(addToJob);
                            e.JobRelateds.Remove(relatedJob);
                        }
                    }
                    e.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var failure in ex.EntityValidationErrors)
                    {
                        string validationErrors = "";
                        foreach (var error in failure.ValidationErrors)
                        {
                            validationErrors += error.PropertyName + "  " + error.ErrorMessage;
                        }
                    }
                }
            }
            return View();
        }
	
