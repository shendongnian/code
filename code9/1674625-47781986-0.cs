    IList<StudentViewmodel> students = null;
    
    using (var CTX = new StudentEntities())
    {
        students = CTX.Students.Include("JP").ToList().Select(
            s => new StudentViewmodel()
            {
                Id = s.StudentId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                address =  new AddressViewmodel()
                {
                    // Address1 = s.StudentAddresses.ToList().Select(t => t.Address1).ToString()
                    Address1 = s.StudentAddresses.OfType<AddressViewmodel>().FirstOrDefault().Address1.ToString()
                }
            }
    
            ).ToList<StudentViewmodel>();
    }
