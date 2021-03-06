        List<RowAndCol> lstrc = new List<RowAndCol>();
        private void Form1_Load(object sender, EventArgs e)
        {
            var file = File.ReadLines("E:\\SAMPLE_FILE\\sample.txt");
            var getList = (from f in file.ToList() where f.Contains("Level") select f).ToList();
            int cnt = 0;
            foreach (var fl in getList.ToList())
            {
                RowAndCol rl = new RowAndCol();
                String[] s = fl.Split(',');
                String[] rowValue = s[1].Trim().Split(':');
                String[] colValue = s[2].Trim().Split(':');
                rl.Chromosome = "Chromosome " + cnt;
                rl.rowtext = "Row";
                rl.coltext = "Col";
                rl.row = rowValue[1].ToString();
                rl.col = colValue[1].ToString();
                lstrc.Add(rl);
                cnt += 1;
            }
        }
        public class RowAndCol
        {
            public string Chromosome { get; set; }
            public String rowtext { get; set; }
            public String coltext { get; set; }
            public String row { get;set; }
            public String col { get; set; }
        }
