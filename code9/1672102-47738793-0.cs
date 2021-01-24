    private int DecemberNodes()
        {
            ManufacturingDataModel MDM = new ManufacturingDataModel();
            Test t = new Test(MDM);
            List<Hardware> decembernodes = t.GetHardware().FindAll(x => x.Date.Month==12);
            int DecemberSumOfNodes = 0;
            foreach (Hardware i in decembernodes)
            {
                DecemberSumOfNodes += i.Nodes;
            }
            return DecemberSumOfNodes;
        }
        private int JanuaryNodes()
        {
            ManufacturingDataModel MDM = new ManufacturingDataModel();
            Test t = new Test(MDM);
            List<Hardware> januarynodes = t.GetHardware().FindAll(x => x.Date.Month==01);
            int JanuarySumOfNodes = 0;
            foreach (Hardware i in januarynodes)
            {
                JanuarySumOfNodes += i.Nodes;
            }
         private void DisplayDecemberData()
        {
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                    {
                          Title = "Nodes",
                          Values = new ChartValues<int> { DecemberNodes()  }
                    },
                 
            };
         private void DisplayJanuaryData()
        {
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                    {
                          Title = "Nodes",
                          **Values = new ChartValues<int> { DecemberNodes(),  JanuaryNodes()  }**
                    },
            };
