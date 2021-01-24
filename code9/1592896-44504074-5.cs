    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApp1
    {
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
				var myListViewVar = this.FindName("myListView") as ListView;
				string[] rowItems = new string[10];
				for (int i = 0; i < 10; i++)
				{
					rowItems[i] = i.ToString();
				}
				for (int i = 0; i < 10; i++)
				{
					var item = new ListViewItem { Content = rowItems[i] };//Each ListViewItem holds an individual string rather than an array
					myListViewVar.Items.Add(item);//Then add that ListViewItem.
				}
			}
		}
    }
