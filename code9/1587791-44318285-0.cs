    public void UpdateUser(UserEntity entity)
        {
  
            var updentity = this.dataContext.Users.Include(e => e.DepartmentUnits).FirstOrDefault(e => e.Id == entity.Id);
            if (updentity == null)
                throw new NullReferenceException("User not found");
            updentity.Status = entity.Status;
         
            updentity.DepartmentUnits = entity.DepartmentUnits.Select(e => this.dataContext.Units.Find(e.Id)).ToList();
            try
            {
                this.dataContext.SaveChanges();
                
            }
            catch (Exception)
            {
                throw new Exception("Update problem");
