    public ActionResult Index(MyProject.Models.SelectModel selectmodel, string txtAmount)
            {
               string percentvalue = Request.Form["txtpcent"];   
                //here add as many request.form we want.  
                MyProjectViewModel vm = new MyProjectViewModel();
                DataSet ds = selectmodel.FilterTransactions(txtAmount);
                vm.Transactions = ds.Tables[0];
        
                return View(vm);
            }
