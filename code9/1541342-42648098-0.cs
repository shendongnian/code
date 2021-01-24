    Timer timer;
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
    void timer_Tick(object sender, EventArgs e)
            {
                Random rand = new Random();
                int r = rand.Next(1000,10000);
                for (int i = 0; i < 10; i++)
                {
                    list1[i] = new Data(r.ToString(), "Category" + r.ToString(), "Desc" + r.ToString(), r.ToString() + "Data");
                    list2[i] = new Data(r.ToString(), "Category" + r.ToString(), "Desc" + r.ToString(), r.ToString() + "Data");
                r = rand.Next(1000, 10000);
            }
            GridRangeInfo range1 = this.gridListControl1.Grid.ViewLayout.VisibleCellsRange;
            GridRangeInfo range2 = this.gridListControl2.Grid.ViewLayout.VisibleCellsRange;
            this.gridListControl1.Grid.RefreshRange(range1);
            this.gridListControl2.Grid.RefreshRange(range2);
        }
        public void Init()
        {
            list1 = new List<Data>();
            list2 = new List<Data>();
            Random rand = new Random();
            int r = rand.Next(100);
            for (int i = 0; i < 10; i++)
            {
                
                list1.Add(new Data(r.ToString(), "Category" + r.ToString(), "Desc" + r.ToString(), r.ToString() + "Data"));
                r = rand.Next(100);
                list2.Add(new Data(r.ToString(), "Category" + r.ToString(), "Desc" + r.ToString(), r.ToString() + "Data"));
            }
        }
        private void btn_Start_Click(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Start();
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }
    //To disable the VerticalScrollbar
    this.gridListControl1.Grid.VScrollBehavior = Syncfusion.Windows.Forms.Grid.GridScrollbarMode.Disabled;
   
