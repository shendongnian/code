    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace PopulatingDataGridColumns_42584334
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                List<int> list_AmountNeed = new List<int>() { 3, 6, 7, 8, 9, 12 };
                List<int> list_TotalCost = new List<int>() { 4, 3, 6, 9, 65, 87 };
                List<int> list_TotalLose = new List<int>() { 7, 9, 2, 5, 15, 27 };
                List<int> list_TotalGain = new List<int>() { 3, 1, 2, 2, 0, 4 };
    
                List<gridviewdata> mydatalist = new List<gridviewdata>();
                for (int i = 0; i < list_AmountNeed.Count; i++)
                {
                    mydatalist.Add(new gridviewdata
                    {
                        col1 = list_AmountNeed[i].ToString(),
                        col2 = list_TotalCost[i].ToString(),
                        col3 = list_TotalLose[i].ToString(),
                        col4 = list_TotalGain[i].ToString()
                    });
                }
                dataGridView1.DataSource = mydatalist;//assuming the datagridview is named dataGridView1
            }
        }
    
    
        class gridviewdata
        {
            public string col1 { get; set; }
            public string col2 { get; set; }
            public string col3 { get; set; }
            public string col4 { get; set; }
        }
    }
