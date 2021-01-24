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
				var item = new ListViewItem { Content = rowItems };//You are adding your string array to a singular element. It does not want it. It wants a nice string.
				var itemsList = new List<ListViewItem>();//You then wrap this singular item in a list. I'm inferring the type here, since the rest of your code does not reference it.
				itemsList.Add(item);
				myListViewVar.Items.Add(item);//You then add the ARRAY to the list of items. Again, this is not desired. See https://msdn.microsoft.com/en-us/library/system.windows.forms.listview.items(v=vs.110).aspx for usage examples.
			}
		}
    }
