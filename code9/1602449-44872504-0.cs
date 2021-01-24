    public Task<Department> GetDepartmentWithOrWithoutProductsAsync(int deptId, bool includeProducts) {
        if(includeProductss) {
            return db.Departments.Include(c => c.Products).Where(s => s.deptId == deptId).SingleAsync();
        }
        return db.Departments.Where(s => s.deptId == deptId).SingleAsync();
    }
