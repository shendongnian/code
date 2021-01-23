    public ActionResult Index()
        {
            documentVerificationBAL objBAL = new documentVerificationBAL();
            string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            List<Records> documentstobeVerified = objBAL.getverificationRecords();
            //Assigning recieved data to Model
            detailsbyclientIdviewModel  model = new detailsbyclientIdviewModel()
            {
                records = documentstobeVerified,
                detailsbyclientId=new IPagedList<detailsbyclientId>()
            };
            return View(model);
        }
