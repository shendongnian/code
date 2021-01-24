    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
	namespace EventStringTest
	{
	    public partial class Form1 : Form
	    {
	        Model md = Model.Instance;
	        public Form1()
	        {
	            InitializeComponent();
	            textBox1.DataBindings.Add("Text", md, "Text", false
					, DataSourceUpdateMode.OnPropertyChanged);
				this.OnBindingContextChanged(EventArgs.Empty);
				textBox1.TextChanged += (object sender, System.EventArgs e) => { };
	        }
			private void Form1_Load(object sender, EventArgs evt)
			{
				md.PropertyChanged += (object s, PropertyChangedEventArgs e) =>	{ };
				// This is just to start make Text Changed in Model.
				md.TimerGO ();
			}
	    }
	}
