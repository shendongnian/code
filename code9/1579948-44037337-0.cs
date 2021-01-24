     protected void Page_Load(object sender, EventArgs e)
            {
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Server.MapPath("test/test.txt"));
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
               string path =  Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
    
                Response.Write(path + "\n");
    
                string[] lines = System.IO.File.ReadAllLines(path);
     
                foreach (string line in lines)
                {
    
                    Response.Write(line);
                }
    
            }
