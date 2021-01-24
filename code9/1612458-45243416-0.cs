    private List<User> PlayersList;
    
    public Tester()
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
    
                    string readString = "select * from user";
    
                    SqlCommand readCommand = new SqlCommand(readString, connect);
    
                    using (SqlDataReader dataRead = readCommand.ExecuteReader())
                    {
                        if (dataRead != null)
                        {
                            while (dataRead.Read())
                            {
                                string tempEmail = dataRead["Email"].ToString();
                                string tempName = dataRead["Name"].ToString();
    
                                UserCollection.addUser(tempEmail, tempName);
                            }
                        }
                    }
    
                    connect.Close();
                }
    
                PlayersList = UserCollection.ReturnUserList();
            }
    
            public class User
            {    
                public string email;
                public string name;
    
                // A constructor that takes parameter to set the properties
                public User(string e, string n)
                {
                    email = e;
                    name = n;
                }
            }
            
    
            public static class UserCollection
            {    
                private static List<User> UserList = new List<User>();
    
                // add a user
                public static void addUser(string email, string name)
                {
                    UserList.Add(new User(email, name));
                }
    
                //return list of users for use elsewhere
                public static List<User> ReturnUserList()
                {
                    return UserList;
                }
            }
