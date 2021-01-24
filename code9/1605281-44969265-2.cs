    public MyCompleteList ReadOrganisations()
    {
        MyCompleteList resp = new MyCompleteList ();
        try
        {
            resp = Execute(() => {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    DC_Base browser_request = new DC_Base(PROJECT);
                    browser_request.cmd_user_id = coreDb.GetUserIDFromLoginName(PROJECT,
                        HttpContext.Current.User.Identity.Name);
                    resp =
                        new MyCompleteList (coreSc.User_Read_All_Organisations(browser_request, utils,
                            validation, coreSc, coreDb));
                    scope.Complete();
                }
                else
                {
                    resp.SetResponseNotLoggedIn();
                }
           });
        }
        catch (TransactionAbortedException ex)
        {
            resp.SetResponseServerError();
        }
        catch (ApplicationException ex)
        {
            resp.SetResponseServerError();
        }
        return resp;
    }
