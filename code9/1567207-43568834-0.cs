        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Mainlistview);
    
            ListView ListView = FindViewById<ListView>(Resource.Id.listView1);
            Selling.WebServiceDB ws = new Selling.WebServiceDB();
            ws.OrderStatusListCompleted += Ws_OrderStatusListCompleted;
            ws.OrderStatusListAsync(Convert.ToString(1));
           
           
        }
        private void Ws_OrderStatusListCompleted(object sender, Selling.OrderStatusListCompletedEventArgs e)
        {
            ListView ListView = FindViewById<ListView>(Resource.Id.listView1);
            string msg = "";
             if (e.Result.QtqSlit.ToString().Equals("0"))
            {
                msg = e.Result.Message;
            }
            else
            {
            
                // full class
                List<TableItem> tableItems = new List<TableItem>();
                tableItems.Add(new TableItem("" + e.Result.QtqSlit, "" + e.Result.QtyPcs, Resource.Drawable.Icon));
                ListView.Adapter = new HomeScreenAdapter(this, tableItems);
            }
    
        }
