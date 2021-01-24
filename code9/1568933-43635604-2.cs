            if (ModelState.IsValid)
            {
                try
                {
                    _companyListService.AddCompanyList(
                    new CompanyList(_userManager.FindById(GetUserId()).UserPK, vm.Name));
                    //------------------------------------------------^
                    //or in the optimistic design :):
                    //new CompanyList(GetUserId(), vm.Name));
                   _companyListService.SaveCompanyList();
                }
                catch (Exception e)
                {
                    _nlogger.Error(e);
                    ViewData["EditError"] = e.Message;
                }
            }
