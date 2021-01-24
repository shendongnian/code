        public Form1()
        {
            // Initialisations left out
            dg.AutoGenerateColumns = false;
            dg.AllowUserToAddRows = true;
            dg.Columns["ID"].DataPropertyName = "ID";
            dg.Columns["Customer"].DataPropertyName = "Customer";
      
            bs.DataSource = typeof(List<Record>);
            bs.AllowNew = true;
            dg.DataSource = bs;
           
            displayNewBlock(0);
        }
          
        private void numUpDown_ValueChanged(object sender, EventArgs e)
        {
            displayNewBlock((int)numUpDown.Value);
        }
        private void displayNewBlock(int blockIndex)
        {
            bs.Clear();
            foreach (Record row in blockList[(int)numUpDown.Value])
                bs.Add(row);
        } 
