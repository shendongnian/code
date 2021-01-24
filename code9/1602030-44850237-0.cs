    //PersonalPageModel personalPageModel = new PersonalPageModel();---> remove this
    
        // GET: PersonalPage
        public ActionResult PersonalPage()
        {
            PersonalPageModel personalPageModel = new PersonalPageModel(); // use here in the action method instead
            List<USERS> list_Users = new List<USERS>();
            List<PERSONAL_INF> list_PersonalInf = new List<PERSONAL_INF>();
    
            personalPageModel.list_Users = list_Users;
            personalPageModel.list_PersonalInf = list_PersonalInf;
    
            personalPageModel.ChangePasswordErrorMessage = "Новый пароль совпадает со старым!";
    
            return View("~/Views/Home/PersonalPage.cshtml", personalPageModel);
        }
