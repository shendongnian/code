       using (StreamReader sr = new StreamReader(sfile))
       {
            //while there is more data to read
            while (sr.Peek() != -1)
            {
                //read first name and last name
               sFirstName = sr.ReadLine();
               sLastName = sr.ReadLine();
                 //does this name match?
                if (sFirstName + sLastName == txtSearchName.Text)
                    break;
            }
         }
        using (StreamWriter sw = new StreamWriter(sfile, true))
        {
            sw.WriteLine("First Name:" + sFirstName);
            sw.WriteLine("Last Name:" + sLastName);
            sw.WriteLine("Gender:" + sGender);
        }
