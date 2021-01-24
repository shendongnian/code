	using System;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Input;
	namespace testit
	{
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
				Grid mainGrid = (Grid)FindName("MainGrid");
				mainGrid.MouseLeftButtonDown += ClickInNowhere;
				TextBlock tb = new TextBlock
				{
					Text = "hello\nworld"
				};
				tb.MaxWidth = 100;
				tb.MaxHeight = 100;
				mainGrid.Children.Add(tb);
				tb.MouseLeftButtonDown += ClickOnBox;
			}
			private void ClickInNowhere(object o, MouseButtonEventArgs args)
			{
				tb.Text = "hello\nworld";
			}
			private void ClickOnBox(object o, MouseButtonEventArgs args)
			{
				tb.Text += "a";
				args.Handled = true;
			}
		}
	}
