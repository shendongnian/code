    public ActionResult UserRegister(Register Register)
        {
            try
            {
                DbConnection dbHandle = new DbConnection();
                dbHandle.Connection();
                
                 using (SqlCommand UserRegistercmd = new SqlCommand("USPUserRegistration", dbHandle.con))
                    {
                        DateTime dob = Convert.ToDateTime(Register.dateOfBirth);
                        string Random = System.DateTime.Now.ToString("ddMMyyhhmmss");
                        Register.UserPhoto = "../Images/" + Random + Register.userImg.FileName;
                        Register.userImg.SaveAs(Server.MapPath("../Images/") + Random + Register.userImg.FileName);
                        UserRegistercmd.CommandType = CommandType.StoredProcedure;
                        
                        dbHandle.con.Open();
                        UserRegistercmd.ExecuteNonQuery();
                        dbHandle.con.Close();
                        ViewBag.error = "Company Registration Sucess";
                        Mail.SendMail(Register.email,"Your User Name and Password ","User Name :"+Register.username+"Paassword :"+Register.password);
                    }
            }
            catch (Exception e)
            {
                ViewBag.error = "Error!!";
                ExceptionLog.Log(e, Request.UserHostAddress);
                return RedirectToAction("Error_View", "CompanyRegister");
            }
            finally
            {
                Dispose();
            }
            return RedirectToAction();
        }
