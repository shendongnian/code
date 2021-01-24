                //login
                bool valid = mp.ValidateUser(username, password);
                if (valid)
                {
                    System.Web.Profile.ProfileBase pro = new System.Web.Profile.ProfileBase();
                    System.Collections.Specialized.NameValueCollection config_profile = new System.Collections.Specialized.NameValueCollection();
                    config_profile.Add("connectionString", connectionstring);
                    config_profile.Add("applicationName", "/");
                    pro.Initialize(username, true);
                    string Name = pro.GetPropertyValue("Name").ToString();
                    string Family = pro.GetPropertyValue("Family").ToString();
                    string phone = pro.GetPropertyValue("Phone").ToString();
                    string address = pro.GetPropertyValue("Address").ToString();
                   
                   
                }
