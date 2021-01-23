    private IEnumerable<Doctor> From(IEnumerable<DoctorsList> doctorList)
    {
       return  doctorList.Select(x=> new Doctor()
                                    {
                                       Name = x.Name?? null,
                                       Id = x.Id?? null
                                   });
    }
    
        
