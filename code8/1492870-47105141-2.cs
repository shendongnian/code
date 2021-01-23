    namespace XamDataGridDemo
    {
        using System.Collections.Generic;
        using System.Windows;
    
        using Infragistics.Controls.Editors;
        using Infragistics.Windows.DataPresenter;
        using Infragistics.Windows.DataPresenter.Events;
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                this.Persons = new List<Person>
                                   {
                                       new Person { Id = 0, FirstName = "Horst", LastName = "Horstenson", Age = 55 },
                                       new Person { Id = 1, FirstName = "Hilde", LastName = "Wild", Age = 45 },
                                       new Person { Id = 2, FirstName = "Klaus", LastName = "Klausen", Age = 50 }
                                   };
    
                DataContext = this.Persons;
                InitializeComponent();
            }
    
            public IList<Person> Persons { get; }
    
            private void PersonGrid_OnRecordActivated(object sender, RecordActivatedEventArgs e)
            {
                var xamDataGrid = (XamDataGrid)sender;
                var activePerson = xamDataGrid.ActiveDataItem as Person;
                if (activePerson != null)
                {
                    // if you want to do something with the properties
                    int id = activePerson.Id;
                    string firstName = activePerson.FirstName;
                    string lastName = activePerson.LastName;
                    int age = activePerson.Age;
    
                    MessageBox.Show($"You have selected {activePerson}", "Selected Person");
                }
                
                // Second Approch -- Your Watchlist
                var record = xamDataGrid.ActiveRecord as DataRecord;
                activePerson = record?.DataItem as Person;
                if (activePerson != null)
                {
                    MessageBox.Show($"You have selected {activePerson}", "Selected Person");
                }
            }
    
            private void XamMultiColumnComboEditor_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                var xamMultiColumnComboEditor = (XamMultiColumnComboEditor)sender;
                var activePerson = xamMultiColumnComboEditor.SelectedItem as Person;
    
                if (activePerson == null)
                {
                    return;
                }
    
                MessageBox.Show($"You have selected {activePerson}", "Selected Person");
    
                // Have to add reference to InfragisticsWPF4.DataManager.v16.1.dll
                if (xamMultiColumnComboEditor.SelectedValue is int)
                {
                    int id = (int)xamMultiColumnComboEditor.SelectedValue;
    
                    MessageBox.Show($"You have selected the person with id: {id}", "Selected Value");
                }
            }
        }
    }
