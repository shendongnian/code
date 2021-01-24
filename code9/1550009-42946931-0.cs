       UserCollection managerGroupUsers = _managerGroupName.Users;                         
                            clientContext.Load(managerGroupUsers);
                            clientContext.ExecuteQuery();
                            string[] Username=null;
                            foreach (User u in managerGroupUsers)
                            {
                                 Username= u.Title.Split(' ');
                                string firstName = Username[0];
                                string LastName = Username[1];
                            }
