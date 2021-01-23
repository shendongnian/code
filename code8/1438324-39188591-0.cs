     public partial class Form1 : Form
    {
        //Your form
        public Form1()
        {
            InitializeComponent();
            //Wrap your objects in a binding list before setting it as the 
            //datasource of your datagrid
            BindingList<Identification> ids = new BindingList<Identification>
            {
                new Identification() { status="NEW"  },
                 new Identification() { status="NEW"  },
                  new Identification() {status="NEW"  },
            };
            dataGridView1.DataSource = ids;
        }
        private void btnChangeStatus_Click(object sender, EventArgs e)
        {   //Where the actual status changing takes place
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var identifaction = row.DataBoundItem as Identification;
                identifaction.status = "VERIFIED";
            }
        }
        //Model: Class that carries your data
        class Identification: INotifyPropertyChanged
        {
            private string _status;
            public string status
            {
                get { return _status; }
                set
                {
                    _status = value;
                    NotifyPropertyChanged("status");
                }
            }
            
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }    
      
    }
