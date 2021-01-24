    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace ChangeBackGroundColorOnClickDGV_46325348
    {
    
    
    
        public partial class Form1 : Form
        {
            DataGridView dgv = new DataGridView();
            BindingList<dgventry> dgvList = new BindingList<dgventry>();
            Button btn1 = new Button();
            Button btn2 = new Button();
            Button btn3 = new Button();
    
            public Form1()
            {
                InitializeComponent();
                InitializeDGV();
                AddButtons();
                AddData();
            }
    
            private void AddButtons()
            {
                btn1.Location = new Point(5, dgv.Location.Y + dgv.Height + 5);
                btn2.Location = new Point(btn1.Location.X + btn1.Width + 5, btn1.Location.Y);
                btn3.Location = new Point(btn2.Location.X + btn2.Width + 5, btn1.Location.Y);
                btn1.Text = "click me 1";
                btn2.Text = "click me 2";
                btn3.Text = "click me 3";
                this.Controls.Add(btn1);
                this.Controls.Add(btn2);
                this.Controls.Add(btn3);
            }
    
            private void AddData()
            {
                for (int i = 0; i < 10; i++)
                {
                    dgvList.Add(new dgventry { col1 = "row " + i });
                }
            }
    
            private void InitializeDGV()
            {
                dgv.Location = new Point(5, 5);
                dgv.DataSource = dgvList;
                dgv.CellContentClick += Dgv_CellContentClick;
                this.Controls.Add(dgv);
            }
    
            private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                switch (e.RowIndex)
                {
                    case 1:
                        btn1.BackColor = Color.Aquamarine;
                        break;
                    case 2:
                        btn2.BackColor = Color.Aquamarine;
                        break;
                    default:
                        break;
                }
            }
    
        }
    
        public class dgventry
        {
            public string col1 { get; set; }
            public bool col2 { get; set; }
        }
    }
