    public Person[] Get(string doctorCode)
    {
        using (PharmaOCEAN_LTEntities entities = new PharmaOCEAN_LTEntities())                   
        {
            return entities.Person.Where(e => e.DoctorLicenseNumber == doctorCode).ToArray();
        }
    }
