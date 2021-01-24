    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication55
    {
        class Program
        {
           
            static void Main(string[] args)
            {
                DataTable doctors = new DataTable();
                doctors.Columns.Add("ID", typeof(int));
                doctors.Columns.Add("Doctor Name", typeof(string));
                doctors.Columns.Add("Speciality", typeof(string));
                doctors.Columns.Add("Year Ex", typeof(int));
                doctors.Rows.Add(new object[] { 1, "Alex", "Transplt", 3});
                DataTable patients = new DataTable();
                patients.Columns.Add("ID", typeof(int));
                patients.Columns.Add("Patient Name", typeof(string));
                patients.Columns.Add("Ward", typeof(int));
                patients.Columns.Add("Diseases", typeof(string));
                patients.Rows.Add(new object[] { 5, "Berns", 1234, "Cancer"});
                DataTable patientDoctor = new DataTable();
                patientDoctor.Columns.Add("ID", typeof(int));
                patientDoctor.Columns.Add("Patient ID", typeof(int));
                patientDoctor.Columns.Add("DoctorID", typeof(int));
                patientDoctor.Rows.Add(new object[] { 6,5,1});
                string doctorName = "Alex";
                int doctID = doctors.AsEnumerable().Where(x => x.Field<string>("Doctor Name") == doctorName).Select(x => x.Field<int>("ID")).FirstOrDefault();
                var results = (from patDr in patientDoctor.AsEnumerable()
                               join pat in patients.AsEnumerable() on patDr.Field<int>("Patient ID") equals pat.Field<int>("ID")
                               select new { doctorID = patDr.Field<int>("DoctorID"), patient = pat.Field<string>("Patient Name") })
                               .Where(x => x.doctorID == doctID).Select(x => x.patient).ToList();
            }
      
        }
    }
