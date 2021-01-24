        public DataTable dataTable { get; set; }
        public GridView(dynamic obj)
        {
            InitializeComponent();
            DevExpress.Mobile.Forms.Init();
            dataTable = new DataTable();
            PopulateGridView(obj.UDQUserDefinedQueryID);
        }
        public async void PopulateGridView(string queryid)
        {
            UDQQueryService model = new UDQQueryService();
            dynamic json = await model.GetItemAsync(queryid);
            if(json == null){
                await Navigation.PopToRootAsync();
            }
            AddColumns(json[0]);
			foreach (dynamic item in json)
			{
                AddRow(item);
			}
			grid.ItemsSource =  dataTable;
           
		}
		void AddColumns(dynamic obj)
		{
			foreach (JProperty x in (JToken)obj)
			{
                dataTable.Columns.Add(x.Name, typeof(string));
			}
		}
		void AddRow(dynamic obj)
		{
			DataRow row = dataTable.NewRow();
	
			foreach (JProperty x in (JToken)obj)
			{
                row[x.Name] = x.Value;
			}
			dataTable.Rows.Add(row);
		}
