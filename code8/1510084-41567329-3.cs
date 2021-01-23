    JObject o = JObject.Parse(user_db);
            foreach (var i in o["ValidateUser"])
            {
                dynamic data = JObject.Parse("" + o["ValidateUser"][j]);
                foreach (var pair in parsed)
                {
                    if (string.Equals(user_name.Text, data.username))
                    {
                        if(string.Equals(password.Text,data.pass))
                        {
                            MessageBox.Show("Success");
                        }
                    }
                }
                j++;
            }
