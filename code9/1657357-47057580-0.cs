    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            DataGridView peopleDataGridView;
            ListBox phonesListBox;
            List<Person> people;
            public Form1()
            {
                //InitializeComponent();
                peopleDataGridView = new DataGridView { Parent = this, Dock = DockStyle.Top };
                phonesListBox = new ListBox { Parent = this, Dock = DockStyle.Bottom };
                people = new List<Person> {
                    new Person { Id=1, Name="John", Phones=new List<string> { "123", "456" } },
                    new Person { Id=2, Name="Smit", Phones=new List<string> { "789", "012" } }
                };
            
                var peopleBindingSource = new BindingSource();
                peopleBindingSource.DataSource = people;
                peopleDataGridView.DataSource = peopleBindingSource;
                var phonesBindingSource = new BindingSource(peopleBindingSource, "Phones");
                phonesListBox.DataSource = phonesBindingSource;
                phonesListBox.SelectedIndexChanged += PhonesListBox_SelectedIndexChanged;
            }
            private void PhonesListBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                MessageBox.Show(phonesListBox.SelectedItem.ToString());
            }
        }
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<string> Phones { get; set; }
        }
    }
