    public void UpdateDep(CommonLayer.Depratment UpDep)
        {
            CommonLayer.Depratment CheckDepartment = this.getDepartment(UpDep.Department_GUID);
            this.Entities.Entry(CheckDepartment).CurrentValues.SetValues(UpDep);
            this.Entities.Entry(CheckDepartment).State = EntityState.Changed; 
            this.Entities.SaveChanges();
    
        }
