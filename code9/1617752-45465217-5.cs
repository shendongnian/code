    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace CloneMacro
    {
    	/// <summary>
    	/// Interaction logic for MainWindow.xaml
    	/// </summary>
    	public partial class MainWindow : Window
    	{
    		ObservableCollection<Store> stores;
    
    		internal const string TESTFILE = @"C:\Temp\TESTFILE.pcf";
    		public MainWindow()
    		{
    			// Leave this to show the UI
    			InitializeComponent();
    
    			lblProgress.Content = "";
    
    			OpenFile( TESTFILE );
    		}
    
    		internal void OpenFile( string fileName )
    		{
    			stores = ReadCSV( TESTFILE );
    			lvStores.ItemsSource = stores;
    		}
    
    		// Fill ListView
    		public class Store : INotifyPropertyChanged
    		{
    			public event PropertyChangedEventHandler PropertyChanged;
    			protected void OnPropertyChanged( string name )
    			{
    				PropertyChangedEventHandler handler = PropertyChanged;
    				if ( handler != null )
    				{
    					handler(this, new PropertyChangedEventArgs(name));
    				}
    			}
    
    			public string sName { get; set; }
    			public string sImportFile { get; set; }
    			public string sID { get; set; }
    
    			private bool isChecked;
    			public bool IsChecked
    			{
    				get { return isChecked; }
    				set
    				{
    					if ( isChecked != value )
    					{
    						isChecked = value;
    						OnPropertyChanged("IsChecked");
    					}
    				}
    			}
    
    			public Store( string id, string strName, string isChecked, string strImportFile )
    			{
    				sName = strName.Replace("\"", "");
    				sImportFile = System.IO.Path.GetFileName(strImportFile);
    				sID = id.Replace("\"", "");
    
    				// Convert isChecked to boolean
    				// Do convertion outside the constructor to avoid any exception within
    				int iBool = Convert.ToInt32(isChecked);
    
    				switch ( iBool )
    				{
    					case 0: IsChecked = false; break;
    					case 1: IsChecked = true; break;
    					default: throw new InvalidOperationException("Third value in PCF file must be 0 or 1!");
    				}
    			}
    		}
    
    		public ObservableCollection<Store> ReadCSV( string fileName )
    		{
    			// Make sure the file extension is pcf
    			string [] lines = File.ReadAllLines(
    				System.IO.Path.ChangeExtension(fileName, ".pcf").Replace("\"", ""), Encoding.GetEncoding(65001));
    
    			// lines.Select allows to project each line as a Store
    			// This will give an IEnumerable<Store> back.
    			var enumerable = lines.Select(line =>
    			{
    				string [] data = line.Split(',');
    				// Return the store data
    				// Return id, Name, isChecked (chkbox checked?), filename
    				return new Store(data [0], data [1], data [2], fileName);
    			});
    
    			stores = new ObservableCollection<Store>();
    			foreach ( var item in enumerable )
    			{
    				stores.Add( item );
    			}
    			return stores;
    		}
    		// End Fill ListView
    
    		private void cmdDelete_Click( object sender, RoutedEventArgs e )
    		{
    			for ( int i = stores.Count - 1; i >= 0; i-- )
    			{
    				if ( stores[i].IsChecked )
    				{
    					stores.RemoveAt( i );
    				}
    			}
    		}
    
    		private void cmdOpen_Click( object sender, RoutedEventArgs e )
    		{
    			OpenFile( TESTFILE );
    		}
    
    	}
    }
