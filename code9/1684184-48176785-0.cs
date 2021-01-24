    public partial class FrmColor : Form
    {
        SqlConnection con = new SqlConnection(@"<YOUR CONNECTION STRING HERE>");
        int pointer = 1;
        int rows = 0;
        public FrmColor()
        {
            InitializeComponent();
        }
        private void btnColor_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Name from Colors Where ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", pointer);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            string colorname = rdr.GetValue(0).ToString();
            con.Close();
            btnColor.Text = colorname;
            if (pointer == rows)
            {
                pointer = 1;
            }
            else
            {
                pointer++;
            }
        }
        private void FrmColor_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select count(Name) From Colors", con);
            con.Open();
            rows = (Int32)cmd.ExecuteScalar();
            con.Close();
        }
    }
