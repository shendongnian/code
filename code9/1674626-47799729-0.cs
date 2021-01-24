            IList<StudentViewmodel> students = null;using (var CTX = new StudentEntities())
            {
                students = CTX.Students.Include("JP").Select(
                    s => new StudentViewmodel()
                    {
                        Id = s.StudentId,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        address = new AddressViewmodel()
                        {
                           Address1 = s.StudentAddresses.FirstOrDefault().Address1 ,
                           Address2 = s.StudentAddresses.FirstOrDefault().Address2,
                           City = s.StudentAddresses.FirstOrDefault().City,
                           State = s.StudentAddresses.FirstOrDefault().State
                        }
                    }
                    ).ToList<StudentViewmodel>();
            }
