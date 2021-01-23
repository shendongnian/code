    "LOGIN FORM" 
    
    Namespace Project1
    
        public partial class AuthenicationForm : Form
        {
            public AuthenicationForm()
            {
                InitializeComponent();
            }
            //Added currentUser
            public static string currentUser;
            private void button1_Click(object sender, EventArgs e)
            {
                SqlConnection con = new SqlConnection(@"blahbalhbalhablh");
                con.Open();
                SqlCommand sqlcmd = new SqlCommand(blahblahblah);
                SqlDataReader sqldr;
                sqldr = sqlcmd.ExecuteReader();
                int count = 0;
                while (sqldr.Read())
                {
                    count += 1;
                }
                if(count == 1)
                {
                    //Grabbed textBox text on buttonclick after filled out
                    currentUser = textBox1.Text;
                    this.Hide();
                    Form1 ss = new Form1();
                    ss.Show();
                }
    
    "Recorder Form"
    
    namespace Project1
    {
        public partial class RecordForm: Form
        {
            public string newFile = "Place to save" + DateTime.Now.ToString("MM-dd-yyyy") + ".csv"; 
            public RecordForm()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                var UPC = textBox1.Text;
                var APCUPC = "00000";
                if (UPC.Length == 9 && UPC.Contains(APCUPC))
                {
                    //grabbed the currentUser from the previous form
                    File.AppendAllText(newFile, LoginForm.currentUser + "," + UPC + "," + DateTime.Now.ToString() + Environment.NewLine);
                    this.BackColor = System.Drawing.Color.Green;
                    this.label1.Text = "Scan successful, continue!";
                    textBox1.Text = "";
                }
                else
                {
                    this.BackColor = System.Drawing.Color.Red;
                    this.label1.Text = "Scan unsuccessful, try again!";
                }
            }
