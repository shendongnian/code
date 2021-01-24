    public class frmPrincipal
    {
        // ....
        // rest of your form Code
    
        private void txtCarga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                this.Hide();
                frmPesquisa frmP = new frmPesquisa(this); // Pass a reference to this form
                frmP.Show();
                con = new SqlConnection(cs.DBConnP);
                con.Open();
    
                string querySelect = @"SELECT CL.Cargs
                                    FROM CargsCab CC (NOLOCK)
                                    INNER JOIN CargsLin CL (NOLOCK) ON CC.Cargs = CL.Cargs
                                    INNER JOIN Stock S (NOLOCK) ON CL.Code = S.Code
                                    WHERE CC.Date >= GETDATE() - 120 AND CL.State NOT IN ('F', 'A') AND S.Type = 'P' 
                                    AND CC.TypeB = 'OCS' AND CL.Cargs LIKE '%" + txtCargs.Text + "%' GROUP BY CL.Cargs ORDER BY CL.Cargs DESC";
                cmd = new SqlCommand(querySelect);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@Cargs", SqlDbType.NChar, 20, "CL.Cargs"));
                cmd.Parameters["@Cargs"].Value = txtCargs.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
    
                DataSet ds = new DataSet();
                da.Fill(ds, "CargsCab");
    
                frmP.dataGridView1.DataSource = ds.Tables["CargsCab"].DefaultView;
    
                txtCarga.SelectAll();
    
                con.Close();
            }
        }
    }
    
    public class frmPesquisa
    {
        private frmPrincipal frmP;
    
        public frmPesquisa()
        {
            InitializeComponent(); // Default constructor
        }
    
        public frmPesquisa(frmPrincipal frmP) : this()
        {
            this.frmP = frmP;
        }
      
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
    
                // If we have a reference to the main form, then show it
                // and set the txtCarga text
                if (this.frmP != null && !this.frmP.IsDiposed)
                {
                    frmP.Show();
    
                    frmP.txtCarga.Text = dr.Cells[0].Value.ToString();
    
                    frmP.txtCarga.Focus();
                    frmP.txtCarga.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro\nDetalhes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
