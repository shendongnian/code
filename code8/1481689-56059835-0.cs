            NameValueCollection collection = new NameValueCollection();
            collection.Set("c1", Session["CredID"].ToString());
            collection.Set("p1", "");
            collection.Set("p2", Request.Form["ctl00$MainContent$hdnHlthId"]);
            collection.Set("p3", Request.Form["ctl00$MainContent$PresStartDate"]);
            collection.Set("p4", Request.Form["ctl00$MainContent$PrescEndDate"]);
            FileUpload fileUpload = PrescUpload;
            ApiServices<Status> obj = new ApiServices<Status>();
            Status objReturn = obj.FetchObjectUploadAPI("POSTUHRPL", collection, 
             fileUpload, ApiServices<Status>.ControllerType.DU);
        }
