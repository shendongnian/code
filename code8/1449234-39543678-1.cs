    using System;
    using System.Collections;
    using System.Collections.Generic;
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
    using System.Windows.Shapes;
    
    namespace WpfAdvanced
    {
        /// <summary>
        /// Interaction logic for Window2.xaml
        /// </summary>
        public partial class Window2 : Window
        {
            DataGrid b = new DataGrid();
            ArrayList countries = new ArrayList();
            ArrayList lookupCountries = new ArrayList();
    
    
    
            public static ArrayList GetItemsSource(DependencyObject obj)
            {
                return (ArrayList)obj.GetValue(ItemsSourceProperty);
            }
    
            public static void SetItemsSource(DependencyObject obj, ArrayList value)
            {
                obj.SetValue(ItemsSourceProperty, value);
            }
    
            // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty ItemsSourceProperty =
                DependencyProperty.RegisterAttached("ItemsSource", typeof(ArrayList), typeof(Window2), new PropertyMetadata(null, new PropertyChangedCallback(myCallback)));
    
            private static void myCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                TextBlock tb = (TextBlock)d;
                ArrayList v = (ArrayList)e.NewValue;
                bool found = false;
                for (int i = 0; i < v.Count; ++i)
                {
                    dynamic o = v[i];
                    if (o.Name == tb.Text)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                    tb.FontWeight = FontWeights.ExtraBold;
            }
    
    
    
            public Window2()
            {
                InitializeComponent();
    
                dynamic o1 = new { Name = "UK", Capital = "London" };            
                countries.Add(o1);
                dynamic o2 = new { Name = "USA", Capital = "New York" };
                countries.Add(o2);
                dynamic o3 = new { Name = "INDIA", Capital = "New Delhi" };
                countries.Add(o3);
                dynamic o4 = new { Name = "INDIA", Capital = "Shimla" };
                countries.Add(o4);
                
                Dgrd.ItemsSource = countries;
    
                dynamic c1 = new { Name = "UK" };
                lookupCountries.Add(c1);
                dynamic c2 = new { Name = "INDIA" };
                lookupCountries.Add(c2);
                dynamic c3 = new { Name = "SRILANKA" };
                lookupCountries.Add(c3);
    
                Cmb.ItemsSource = lookupCountries;
            }
    
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                CollectionViewSource.GetDefaultView(Dgrd.ItemsSource).Filter = grdFilter;
            }
    
            private bool grdFilter(dynamic obj)
            {
                dynamic i = Cmb.SelectedItem;
    
                return (obj.Name == i.Name);
            }
        }   
    }
