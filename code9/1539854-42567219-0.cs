    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                List<myclass> mylist = new List<myclass>();
                mylist = Fillmylist(mylist);
                this.Controls.Add(mylist[0].chckbx_Recurse);
                this.Controls.Add(mylist[0].txtbx_pwd);
                this.Controls.Add(mylist[0].txtbx_usrname);
            }
    
            private List<myclass> Fillmylist(List<myclass> incominglist)
            {
                TextBox tb = new TextBox();
                tb.Name = "txtbx_usr";
                tb.SetBounds(20, 20, 50, 10);
                TextBox tbp = new TextBox();
                tbp.Name = "txtbx_pwd";
                tbp.SetBounds(20,50, 50, 10);
                CheckBox cb = new CheckBox();
                cb.Name = "chkbx_recurse";
                cb.SetBounds(20, 80, 20, 20);
                incominglist.Add(new myclass { txtbx_usrname = tb, txtbx_pwd = tbp, chckbx_Recurse = cb });
                return incominglist;
            }
        }
    
    
    
        class myclass
        {
            public TextBox txtbx_usrname { get; set; }
            public TextBox txtbx_pwd { get; set; }
            public CheckBox chckbx_Recurse { get; set; }
    
        }
    }
