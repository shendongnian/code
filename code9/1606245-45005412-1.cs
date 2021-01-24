    public class UserManagement: Controller {
        public ActionResult ExportToCSV(int ugid)
                {
                    client.Open();
                    List<UserObjUserInfo> userlistbyUGID = client.GetUserListByUGID(ugid, "token").ToList();
                    client.Close();
        
                    StringWriter sw = new StringWriter();
        
                    sw.WriteLineCSV("USER ID","USERNAME","NAME","CREATE DATE");
        
                    Response.ClearContent();
                    Response.AddHeader("content-disposition", "attachment;filename=Exported_Users.csv");
                    Response.ContentType = "text/csv";
        
                    foreach (var user in userlistbyUGID)
                    {
                        sw.WriteLineCSV(user.ugid,user.username,user.name, user.CreateDate);
                    }
                    Response.Write(sw.ToString());
                    Response.End();
                }
    
                   }
    }
