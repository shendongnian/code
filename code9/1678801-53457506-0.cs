    public ActionResult Index()
        {
            var Usn01 = User.Identity.GetUserId().ToString();
            var settings = Properties.Settings.Default;
            var formData = HttpContext.Request.Form;
            
            using (var db = new Database(settings.DbType, settings.DbConnection))
                {
                var response = new Editor(db, "users", "usID")
                        .Model<usersDb>()
                        .Where(x => x.Where("teamID", "(SELECT teamID FROM dimTeamLead 
                                            WHERE userID = '" + Usn01 + "')", "IN", false))
                        .Where(y => y.Where("IsActive",1));
                var resp = Json(response.Process(formData)
                       .Data(), JsonRequestBehavior.AllowGet);
                return resp;
            }
        }
