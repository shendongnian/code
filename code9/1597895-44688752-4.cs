    public ActionResult Index(MyProject.Models.SelectModel selectmodel, string txtAmount,string txtpcent,.....)
        {
            MyProjectViewModel vm = new MyProjectViewModel();
            DataSet ds = selectmodel.FilterTransactions(txtAmount);
            vm.Transactions = ds.Tables[0];
    
            return View(vm);
        }
