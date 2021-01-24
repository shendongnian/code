    public Form1()
        {
              int rowListLength = 2;
                int blockListLength = 3;
                blockList = new List<List<Record>>(blockListLength);
                for (int i = 0; i < blockListLength; i++)
                {
                    blockList.Add(new List<Record>());
                    blockList[i] = new List<Record>(rowListLength);
                    for (int j = 0; j < rowListLength; j++)
                        blockList[i].Add(new Record(10 * i + j, "name_" + (10 * i + j).ToString()));
                }
    
                //dg.AutoGenerateColumns = false;
                //dg.Columns["ID"].ReadOnly = false;
                //dg.Columns["ID"].DataPropertyName = "ID";
                //dg.Columns["Customer"].DataPropertyName = "Customer";
    
                bs.DataSource = typeof(List<List<Record>>);
                foreach (List<Record> block in blockList)
                    bs.Add(block);
                bs.CurrencyManager.Position = 0;
                dg.DataSource = (List<Record>)bs.CurrencyManager.Current;
    
        }
