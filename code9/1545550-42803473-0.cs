    class Program
    {
     public class tmpClass
        {
            public string Text;
            public bool tick;
        }
        
        public List<tmpClass> tmpList = new List<tmpClass>();
        
        static void Main(string[] args)
        {
               //Stuff         
        }
        
        public void WriteToFile()
        {
            string tmpTextFilePath = @"C:\User\Desktop\SaveText.txt";
        
            using (StreamWriter tmpWriter = new StreamWriter(tmpTextFilePath))
            {
                string tmpTextToWrite = String.Empty;
                for (int i = 0; i < tmpList.Count; i++)
                {
                    tmpClass tmpEntry = tmpList[i];
                    tmpTextToWrite += tmpEntry.Text + ";" + tmpEntry.tick;
                }
                tmpWriter.WriteLine(tmpTextToWrite);
            }
            //Now we wrote a text file to you desktop with all Informations
        }
        
        public void ReadFromFile()
        {
            string tmpTextFilePath = @"C:\User\Desktop\SaveText.txt";
            using (StreamReader tmpReader = new StreamReader(tmpTextFilePath))
            {
                string tmpText = tmpReader.ReadLine();
                string tmpInput = String.Empty;
                tmpClass tmpClass = new tmpClass();
                int i = 0;
                foreach (char item in tmpText)
                {
                    if(item.Equals(";".ToCharArray()))
                    {
                        if (i == 0)
                        {
                            tmpClass.Text = tmpInput;
                            i = 1;
                            tmpInput = String.Empty;
                        }
                        else
                        {
                            if (tmpInput == "True")
                                tmpClass.tick = true;
                            else
                                tmpClass.tick = false;
                            i = 0;
                            tmpInput = String.Empty;
                            tmpList.Add(tmpClass);
                        }
                    }
                    tmpInput += item;
                }
            }
        }
     }
