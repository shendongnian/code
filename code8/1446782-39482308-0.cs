            username = UserController.GetCurrentUserInfo().Username.ToString();
            
        }
                
        protected void Button1_Click1(object sender, System.EventArgs e)
        {
            var folder = Server.MapPath("~/uploads/Company/" + username);
            if (this.FileUpload1.HasFile)
            {
                Directory.CreateDirectory(folder);
                this.FileUpload1.SaveAs(folder + "/" + this.FileUpload1.FileName);            
            }
        }
