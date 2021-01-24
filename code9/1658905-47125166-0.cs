     static void Main(string[] args)
            {
                List<string> abbreviated = new List<string>();
                List<string> expanded = new List<string>();
    
                StreamReader sr = new StreamReader("textwords.csv");
                string TxtWrd = "";
                while ((TxtWrd = sr.ReadLine()) != null)
                {
                    Debug.WriteLine("line: " + TxtWrd);
                    string[] Words = TxtWrd.Split(new char[] { ',' } , StringSplitOptions.None);
                    abbreviated.Add(Words[0]);
                    expanded.Add(Words[1]);
                }
    
                if (abbreviated.Contains("wuu2"))
                {
                    //show message box
                } else
                {
                    //don't
                }
    
            }
