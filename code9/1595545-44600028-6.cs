    public ActionResult Index(MyProject.Models.SelectModel selectmodel,string txtSearchterm)  //when you click submit button here you will get the value 
        {
                 AccountViewModel vm = new AccountViewModel();
        //updated
        DataSet ds = selectmodel.GetAccounts(txtSearchterm);
        vm.Accounts = ds.Tables[0];
        return View(vm);
    
    }
