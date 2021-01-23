    public partial class User
    {
        DatabaseEntities db = new DatabaseEntities();
        OtherEntities otherDB = new CommonEntities();
    
            public void UpdateSupervisor()
            {
                // Lookup the Supervisor's Username in the other Database:
                string supervisorUsername = (from x in otherDB.vwEmployees
                                     join y in otherDB.vwEmployees on x.Supervisor_EID equals y.Employee_ID
                                     where x.User_ID == searchUsername
                                     select y.User_ID).FirstOrDefault();
    
                // Update the database to record the Supervisor of this staff member:
                this.SupervisorUserID = (from x in db.Users
                                         where x.ADUsername == supervisorUsername
                                         select x.UserID).FirstOrDefault();
                // NEW CODE:
                // Create a new user inside the User class, set to the current User by ID:
                User tempUser = db.Users.Find(this.UserID);
                tempUser.SupervisorUserID = this.SupervisorUserID;
                db.SaveChanges();
            }
    }
