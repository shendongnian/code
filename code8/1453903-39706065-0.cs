     using (FileStream fs = System.IO.File.OpenWrite(Server.MapPath("~/FILE/") + logFile))
     {
        using (StreamWriter sw = new StreamWriter(fs))
        {
            //sw.Write(DateTime.Now.ToString() + " sent email to " + email);
            sw.Write(" sent email to ");
        }
        fs.Close();
     }
