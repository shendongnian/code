    public IEnumerable<StudentDetail> GetStudentDetails(int ssid)
        {
            var ssidParam = new SqlParameter("@ssid", ssid);
            var result = _appDbContext.StudentDetails.FromSql("exec GetStudentDetail @ssid", ssidParam).AsNoTracking().ToList();
            return result;
        }
