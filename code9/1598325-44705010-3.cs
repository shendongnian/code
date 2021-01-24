    public class UserDatabase
    {
        readonly SQLiteAsyncConnection database;
    
        public UserDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User_Profiles>().Wait();
            // Don't do that (Your User's attribute will be persisted within your User_Profiles table): database.CreateTableAsync<User>().Wait();
            database.CreateTableAsync<Medicine>().Wait();
            database.CreateTableAsync<Medicine_Incident>().Wait();
        }
    
        public void SaveProfileAsync(User_Profiles user)
        {
            database.InsertAsync(user);
        }
    
        public Task<User_Profiles> GetProfileAsync(string email, string pass)
        {
            return database.Table<User_Profiles>().Where(i => (i.Email.Equals(email)) && (i.Password.Equals(pass))).FirstOrDefaultAsync();
        }
    
        public void SaveMedicineAsync(Medicine med)
        {
            database.InsertAsync(med);
        }
    
        public void SaveMedicineIncidentAsync(Medicine_Incident med_inc)
        {
            database.InsertAsync(med_inc);
        }
    
        public Task<Medicine_Incident> GetMedicineIncidentAsync(string email, string medName, DateTime time)
        {
            var user = database.Table<User_Profiles>().Where(u => u.Email == email).FirstOrDefault();
            var medicine = database.Table<Medicine>().Where(m => m.Medicine_Name == medName).FirstOrDefault();
            var medInc = database.Table<Medicine_Incident>().Where(mi => mi.IdUser_Profiles == user.Id && mi.IdMedicine == medicine.Id).FirstOrDefault();
            
            medInc.User = user;
            medInc.Medicine = medicine;
            
            return medInc;
        }
    }
