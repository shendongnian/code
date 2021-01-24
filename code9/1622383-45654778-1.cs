    using System;
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    namespace WpfApplication7
    {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            items soureitems = new items();
            for(int i = 0; i <= 10; i++)
            {
                item sourceitem = new item();
                sourceitem.Name = "John";
                sourceitem.LastName = "Doe";
                sourceitem.Caption = "";
                soureitems.Add(sourceitem);
            }
            this.DataContext = soureitems;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            items sourceitems = (items)(this.DataContext);
            this.DataContext = null;
            foreach (item sourceitem in sourceitems)
            {
                if(sourceitem.Caption != "ShowCombobox")
                {
                    sourceitem.Caption = "ShowCombobox";
                } else
                {
                    sourceitem.Caption = "";
                }
            }
            this.DataContext = sourceitems;
        }
    }
    public class items : System.Collections.ObjectModel.ObservableCollection<item> { }
    public class item
    {
        string _Name;
        string _LastName;
        string _Caption;
        public string Name {
            get { return _Name; }
            set { _Name = value; }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public string Caption
        {
            get { return _Caption; }
            set { _Caption = value; }
        }
    }
    }
