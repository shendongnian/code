                System.IO.StreamReader file = new System.IO.StreamReader("UserData.txt");
                string fileLine;
                string line;
                bool isFound = false;
                while ((line = file.ReadLine()) !=null)
                {
                    
                    
                    fileLine = line;
                    System.Diagnostics.Debug.WriteLine(fileLine);
                    string len = fileLine.Length.ToString();
                    string usr = fileLine.Substring(0, 20);
                    string hash = fileLine.Substring(20, 32);
                    if (usr.Contains(UserNameIpt.Text))
                    {
                        if (hash == password)
                        {
                            GlobalVar.UserNameEntered = UserNameIpt.Text;
                            showUserPanel();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Error, password or username incorrect. \r\n\r\nyou may not have an account set up to use this software, please contact the system administartor for assistance.", "Login Error");
                            return;
                        }
                    }
                    
                   
                }
                MessageBox.Show("Error, password or username incorrect. \r\n\r\nyou may not have an account set up to use this software, please contact the system administartor for assistance.", "Login Error");
