    using System;
    using System.IO;
    
    class json
    {
        string FirstName = "";
        string MiddleName = "";
        string LastName = "";
        string FullName = FirstName + " " + MiddleName + " " + LastName;
        FileStream fStream = new FileStream("fileName.docx", FileMode.Open, 
                                             FileAccess.Write, FileAshar.Write);
        public json()
        {}
        public void SendNameToFile(string fName)
        {
             fStream.Write(fName + "\n");
        }
    }
