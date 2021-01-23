		private readonly List<int> _list = new List<int>();
		private BindingList<int> _bList;
		private readonly BindingSource _bSource = new BindingSource();
		private void Form1_Load(object sender, EventArgs e)
		{
			_list.Add(23);
			_list.Add(2);
			_list.Add(5);
			_list.Add(12);
			_list.Add(14);
			_list.Add(8);
			_list.Add(9);
			_list.Add(15);
			_list.Add(21);
			_list.Add(22);
			_list.Add(1);
			_bList = new BindingList<int>(_list);
			_bSource.DataSource = _bList;
			comboBox2.DataSource = _bSource;
			_list.Sort();
			_bList.ResetBindings();
