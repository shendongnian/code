     doSomething(string text)
        {            
            DataTable dt = new DataTable();
            string[] operators = { "+", "*", "/", "-" };
            string[] data = text.Split(' ');
            for(int i=0; i< data.Length; i++)
            {
                if((operators.Any(data[i].Contains)))
                {
                    MessageBox.Show(data[i].ToString());
                    var res = dt.Compute(data[i],"");
                }
            }
        }
