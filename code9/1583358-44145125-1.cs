    using System.Windows;
    using System.ComponentModel;
    
    namespace WpfApplication1
    {
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            BindingList<FamilyMember> Family = new BindingList<FamilyMember>();
    
            public MainWindow()
            {
                InitializeComponent();
                InitializeDG();
                AddFamilyMembers();
            }
    
            private void InitializeDG()
            {
                dg_MainGrid.ItemsSource = Family;
                dg_MainGrid.AutoGenerateColumns = true;
            }
    
            private void AddFamilyMembers()
            {
                Family.Add(new FamilyMember { FName = "Name1", LName = "D", Notes = "34" });
                Family.Add(new FamilyMember { FName = "Name2", LName = "L", Notes = "36" });
                Family.Add(new FamilyMember { FName = "Name3", LName = "D", Notes = "7" });
                Family.Add(new FamilyMember { FName = "Name3", LName = "D", Notes = "5" });
            }
            private void button_Click(object sender, RoutedEventArgs e)
            {
                string TheName = ((FamilyMember)dg_MainGrid.SelectedItem).FName;//get the selected FName
            }
        }
    
        public class FamilyMember
        {
            public string FName { get; set; }
            public string LName { get; set; }
            public string Notes { get; set; }
        }
    }
