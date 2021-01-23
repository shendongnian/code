    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Configuration;
    using System.Data.SqlClient;
    
    namespace Cookbook
    {
        public partial class frmMain : Form
        {
            SqlConnection connection;
            string connectionString;
    
            public frmMain()
            {
                InitializeComponent();
                connectionString = ConfigurationManager.ConnectionStrings["Cookbook.Properties.Settings.CookbookConnectionString"].ConnectionString;
            }
    
            public void frmMain_Load(object sender, EventArgs e)
            {
                PopulateRecipes();
    
            }
    
            public void PopulateRecipes()
            {
                using (connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Recipe", connection))
                    {
                    connection.Open(); //Open connexion 
                    DataTable recipeTable = new DataTable();
                    adapter.Fill(recipeTable);
    
                    lstRecipes.DisplayMember = "Name";
                    lstRecipes.ValueMember = "Id";
                    lstRecipes.DataSource = recipeTable;
                    connection.Close(); //close connexion
                    }
    
                    
            }
    
    
            public void PopulateIngrediants()
            { 
                //Donc forget space in your query when you concat string for create query, add column a.id if you want use in valuemember
                string query = "SELECT a.Name, a.Id FROM Ingrediants a " +
                "INNER JOIN RecipeIngrediant b ON a.Id = b.IngrediantId " +
                "WHERE b.RecipeId = @RecipeId";
    
                //Remove your command
                using (connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    connection.Open() //open connexion
                    adapter.SelectCommand.Parameters.AddWithValue("@RecipeId", lstRecipes.SelectedValue);//modify parameter of select command to dataadapter (verify selectvalue)
                    DataTable ingrediantsTable = new DataTable();
                    adapter.Fill(ingrediantsTable);
    
                    lstIngrediants.DisplayMember = "Name";
                    lstIngrediants.ValueMember = "Id";
                    lstIngrediants.DataSource = ingrediantsTable;
                    connection.Close() //close connexion
                }
            }
    
            public void lstRecipes_SelectedIndexChanged(object sender, EventArgs e)
            {
                PopulateIngrediants();
            }
    
            private void lblRecipes_Click(object sender, EventArgs e)
            {
    
            }
    
            private void frmMain_Load_1(object sender, EventArgs e)
            {
    
            }
        }
    }
