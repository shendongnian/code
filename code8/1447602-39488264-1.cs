    for (int i = 1; i <= 4; i++)
    {
        string StudentName = Request.Form["name" + i].ToString();
        if(String.IsNullOrEmpty(StudentName))
            continue;
        string RegistrationNumber = Request.Form["reg" + i].ToString();
        string Department = Request.Form["dep" + i].ToString();
        string FatherName = Request.Form["Fname" + i].ToString(); 
        Dt.Rows.Add(StudentName, RegistrationNumber, Department, FatherName);
    }
