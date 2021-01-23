	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Windows;
	using System.Windows.Data;
	namespace WpfApplication2
	{
		public class ThingConverter : IValueConverter
		{
			public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
			{
				return new List<string>(((NamedThing)value).Name.Split(' '));
			}
			public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
			{
				return ((List<string>)value).Aggregate((s, ss) => s + " " + ss);
			}
		}
		public class NamedThing
		{
			public string Name { get; set; }
		}
		public class MYViewModel
		{
			public ObservableCollection<NamedThing> ThingsList { get; set; }
			public MYViewModel()
			{
				ThingsList = new ObservableCollection<NamedThing>
				{
					new NamedThing {Name = "Short"},
					new NamedThing {Name = "VeryVeryLongWord"},
					new NamedThing {Name = "Several Words in a Row"}
				};
			}
		}
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
			}
		}
	}
