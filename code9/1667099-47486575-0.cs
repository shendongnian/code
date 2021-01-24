    public class CostData
        {
            public int Cost;
            public int ID;
            public CostData(int CostAmount, int CostID)
            {
                Cost = CostAmount;
                ID = CostID;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<CostData> itemcost = new List<CostData> {
                                                        new CostData(100, 1),
                                                        new CostData(300, 2),
                                                        new CostData(900, 3),
                                                        new CostData(300, 4),
                                                        new CostData(100, 5),
                                                        new CostData(300, 6)
                                                       };
            List<CostData> SortedList = itemcost.OrderByDescending((CostData i) => i.Cost).ToList();
            
            Console.WriteLine(SortedList[0].Cost.ToString() + " on index " + SortedList[0].ID.ToString());
            // you can do same with Arrray
            CostData[] itemcost2 = new CostData[] {
                                                        new CostData(100, 1),
                                                        new CostData(300, 2),
                                                        new CostData(900, 3),
                                                        new CostData(300, 4),
                                                        new CostData(100, 5),
                                                        new CostData(300, 6)
                                                       };
            CostData[] SortedList2 = itemcost2.OrderByDescending((CostData i) => i.Cost).ToArray();
            Console.WriteLine(SortedList2[0].Cost.ToString() + " on index " + SortedList2[0].ID.ToString());
        }
