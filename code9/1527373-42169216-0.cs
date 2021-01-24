            int oid = new int();
            int pid = new int();
            if (Request.QueryString["User"] != null && Request.QueryString["Friend"] != null)
            {
               
                    oid = Convert.ToInt32(Request.QueryString["User"]);
                    OwnerName.Visible = true;
                    UserTable q = Class1.selectByID(oid);
                    OwnerName.Text = q.LName;
                pid = Convert.ToInt32(Request.QueryString["Friend"]);
                FriendName.Visible = true;
                UserTable a = Class1.selectByID(pid);
                FriendName.Text = a.LName;
            }
