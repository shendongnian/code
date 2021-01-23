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
    
                // Update the database to record the Supervisor of this staff member
                this.SupervisorUserID = (from x in db.Users
                                         where x.ADUsername == supervisorUsername
                                         select x.UserID).FirstOrDefault();
    
                // Find user in DBContext using your primary key...
                var user = db.Users.Find(this.ID);
                if (user != null)
                {
                    // User exists in database, update id
                    user.SupervisorUserID = this.SupervisorUserID;
                }
                else
                {
                    // User does not exist in database
                    db.Users.Add(this);
                }
                db.SaveChanges();
            }
    }
