       List<RowAndCol> lstrc = new List<RowAndCol>();
        private void Form1_Load(object sender, EventArgs e)
        {
            var file = File.ReadLines("E:\\SAMPLE_FILE\\sample.txt");
           
            var getList = (from f in file.ToList() where f.Contains("Level") || f.Contains("Chromosome") select f).ToList();
            int cnt = 1;
          
            string chr = string.Empty;
                foreach (var fl in getList.ToList())
                {
                    
                    RowAndCol rl = new RowAndCol();
                    if (fl.Contains("Level"))
                    {
                        String[] s = fl.Split(',');
                        String[] rowValue = s[1].Trim().Split(':');
                        String[] colValue = s[2].Trim().Split(':');
                        rl.Chromosome = chr;
                        rl.rownum = cnt;
                        rl.rowtext = "Row";
                        rl.coltext = "Col";
                        rl.row = rowValue[1].ToString();
                        rl.col = colValue[1].ToString();
                      
                        cnt += 1;
                    }
                    else
                    {
                        chr = fl.ToString();
                    }
                    lstrc.Add(rl);
                }
                cnt = 1;
        }
        public class RowAndCol
        {
            public int rownum { get; set; }
            public string Chromosome { get; set; }
            public String rowtext { get; set; }
            public String coltext { get; set; }
            public String row { get;set; }
            public String col { get; set; }
        }
