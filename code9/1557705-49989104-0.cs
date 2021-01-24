     private void button1_Click(object sender, EventArgs e)
        {
            string s = Clipboard.GetText();
            
            string[] lines = s.Replace("\n", "").Split('\r');
            dgPositions.Rows.Add(lines.Length-1); 
            string[] fields;
            int row = 0;
            int col = 0;
            foreach (string item in lines)
            {
                fields = item.Split('\t');
                foreach (string f in fields)
                {
                    Console.WriteLine(f);
                    dgPositions[col, row].Value = f ;                   
                    col++;
                }
                row++;
                col = 0;
            }
        }
