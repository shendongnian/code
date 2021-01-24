    public partial class Cad_Prod : Form
    {
       private static readonly SQLiteConnection conn1 =
             new SQLiteConnection(("data source=X.s3db");
       private static DataTable produtos;
       private static DataTable produtos;
       private static DataTable AutoDataTable => 
          produtos?? (produtos = GetAutos());           
       private static DataTable CategoryDataTable => 
          categoria ?? (categoria = GetCategories());            
       int prodstart = 0;
       public Cad_Prod() { InitializeComponent(); }
       public void Cad_Prod_Load(object sender, EventArgs e)  {  }
       private static DataTable GetAutos()
       {
          string query = "SELECT * FROM Cad_Prod";
          try
          {
              using (SQLiteCommand comm = new SQLiteCommand(query, conn1))
              using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm))
              {
                conn1.Open();
                DataTable produtos = new DataTable();
                adapter.Fill(produtos); 
                return produtos;
              }
          }
          catch (Exception ex)
          {
              MessageBox.Show(this, ex.Message, "Erro", 
              MessageBoxButtons.OK, MessageBoxIcon.Error);
              throw;
          }
       }
       private static DataTable GetCategories()
       {
          string query2 = "SELECT * FROM Cat";
          try
          {
             using (SQLiteCommand comm2 = new SQLiteCommand(query2, conn1))
             using (SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(comm2))
                {
                conn1.Open();
                DataTable categoria = new DataTable();
                adapter2.Fill(categoria);
                return categoria;
                }
          }
          catch (Exception ex)
          {
              MessageBox.Show(this, ex.Message, "Erro", 
              MessageBoxButtons.OK, MessageBoxIcon.Error);
              throw;
          }
      }
    
      private void PopulateView()
      {
         int auxCat = int.Parse(produtos.Rows[prodstart]
                .ItemArray[4].ToString()) - 1;
         txtProdutoNome.Text = produtos.Rows[prodstart]
                .ItemArray[1].ToString();
         txtProdutoPreco.Text = produtos.Rows[prodstart]
                .ItemArray[2].ToString();
         txtProdutoQtd.Text = produtos.Rows[prodstart]
                .ItemArray[3].ToString();
         cbbCategoria.Text = categoria.Rows[auxCat]
                .ItemArray[1].ToString();
      }
      private void btnAvancar_Click(object sender, EventArgs e)
      {
        prodstart = prodstart + 1;
        PopulateView();
      }
      private void btnVoltar_Click(object sender, EventArgs e)
      {
        prodstart = prodstart - 1;
        PopulateView();
      }
    }
