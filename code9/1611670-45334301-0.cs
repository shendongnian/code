    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp5
    {
        public partial class Form1 : Form, INotifyPropertyChanged
        {
            public Form1()
            {
                InitializeComponent();
    
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = typeof(Form1);
                bindingSource.Add(this);
    
                label1.DataBindings.Add("Text", bindingSource, "CustomProperty1", true,
                    DataSourceUpdateMode.OnPropertyChanged);
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public string CustomProperty1 {
                get { return textBox1.Text; }
                set {
                    NotifyPropertyChanged();
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                textBox1.Text = "thing1";
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                NotifyPropertyChanged("CustomProperty1");
            }
        }
    }
