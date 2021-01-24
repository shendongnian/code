        //declare global variable for student list and filepath
        List<Student> students = new List<Student>();
        string FilePath = AppDomain.CurrentDomain.BaseDirectory + "\\" + Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName) + ".xml";
        private void Form1_Load(object sender, EventArgs e)
          {
              
                string XmlData = string.Empty;
                if (File.Exists(FilePath))
                {
                    using (StreamReader sr = new StreamReader(FilePath))
                    {
                        XmlData = sr.ReadToEnd(); 
                    }
                    students = XmlData.ToClass<List<Student>>();
                }      
          }
