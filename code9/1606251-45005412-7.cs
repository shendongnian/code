    public class UserManagement: Controller {
        public ActionResult ExportToCSV(int ugid)
                {
                    string FileName = "Exported_Users.csv";
                    string FilePath = Server.MapPath(Path.Combine("~/ExportFiles", FileName ));
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
                
                   return File(FilePath, "text/csv", FileName);
           }
        
    }
