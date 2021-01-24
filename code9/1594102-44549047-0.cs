    [WebMethod]
    public void AddEmployementRequest(EmployementRequest emp) {           
        emp.PKEmploymentRequest = Guid.NewGuid();
        using (var db = new UKN_DBNAMEEntities()) {
            db.EmployementRequests.Add(emp);
            db.SaveChanges();
        }
    }
