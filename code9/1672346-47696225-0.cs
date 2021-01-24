    public ActionResult ViewModules(int id)
            {
                Domain_Bind();
                dynamic mymodel = new ExpandoObject();
                userType type = new userType();
    
    
                List<ViewRoleModules> EmpList = type.GetRoleModulesViews(id);
    
                List<ViewRoleModules> RoleList;
                List<ViewRoleModules> test = new List<ViewRoleModules>();
                foreach (int rid in EmpList)
                {
                    string RID = rid;
                    RoleList = type.GetSiteRoleModulesViews(rid);
                    foreach (ViewRoleModules vip in RoleList)
                    {
                        test.Add(new ViewRoleModules
                        {
                            RoleName = vip.RoleName,
                            ModuleId = vip.ModuleId
                        });
                    }
                }
    
                var data = new { EmpList = EmpList, test = test };
    
                return Json(data, JsonRequestBehavior.AllowGet);
    
            }
