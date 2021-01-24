        var doctor = myEntity.Doctors.Where(x=>x.DoctorID == someParameter).SingleOrDefault();
       myEntity.Doctors.Remove(doctor);
        try
        {
            myEntity.SaveChanges();
            MessageBox.Show("Doctor Deleted");
        }
        catch
        {
            MessageBox.Show("Something went wrong");
        }
    }
