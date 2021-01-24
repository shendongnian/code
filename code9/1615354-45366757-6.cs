      using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Media;
    
    namespace WpfApplication3
    {
    	/// <summary>
    	/// Interaction logic for MainWindow.xaml
    	/// </summary>
    	public partial class MainWindow : Window, INotifyPropertyChanged
    	{
    		public Brush BtnBackColor { get; set; } = new SolidColorBrush(Colors.Red);
    		public MainWindow()
    		{
    			InitializeComponent();
    			this.DataContext = this;
    		}
    
    		public event PropertyChangedEventHandler PropertyChanged;
    
    		private void Button_Click(object sender, RoutedEventArgs e)
    		{
    			Random r = new Random();
    
    			//Without Binding variant
    			//btnNext.Background = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
    			//	(byte)r.Next(1, 255), (byte)r.Next(1, 233)));
    
    			//MVVM approach variant
    			BtnBackColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
    				(byte)r.Next(1, 255), (byte)r.Next(1, 233)));
    			OnPropertyChanged("BtnBackColor");
    		}
    		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    		{
    			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    }
