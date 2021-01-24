    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form2 : Form
        {
            DataGridView dgv2 = new DataGridView();
            BindingList<dgv2item> dgv2list = new BindingList<dgv2item>();
    
            //this is the 'default' constructor which takes no argument
            public Form2()
            {
                InitializeComponent();
                MakeTheGrid();
            }
    
            //this form constructor takes a String parameter so you can pass only a string
            public Form2(string incomingText)
            {
                InitializeComponent();
                MakeTheGrid();
                dgv2list.Add(new dgv2item { coolBeans = incomingText });//add the incoming String to the itemList, which will in-turn update the DataGridView
            }
    
    
            //this form constructor takes a DataGridViewRow parameter so you can pass the whole row
            public Form2(DataGridViewRow incomingRow)
            {
                InitializeComponent();
                MakeTheGrid();
                dgv2list.Add(new dgv2item { coolBeans = (string)incomingRow.Cells[0].FormattedValue});//add the value of the cell you want out of the row to the itemlist, which will in-turn update the DataGridView
            }
    
    
            private void MakeTheGrid()
            {
                dgv2.Location = new Point(this.Location.X + 15, this.Location.Y + 15);//it has to go somewhere...
                dgv2.AutoGenerateColumns = true;
                dgv2.DataSource = dgv2list;//define where to find the data
                this.Controls.Add(dgv2);//add it to the form
            }
        }
    
    
        public class dgv2item
        {
            public string coolBeans { get; set; }
        }
    }
