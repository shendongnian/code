    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace ShopshopFinalfinal
    {
        public partial class ShopInterface : Form
        {
    
            private DatabaseConnection dbConnection = new DatabaseConnection();
            private string Username { get; set; }
            private string Password { get; set; }
    
            public ShopInterface(string username, string password)
            {
                InitializeComponent();
                Username = username;
                Password = password;
            }
    
            private void btn_buyapple_Click(object sender, EventArgs e)
            {
    
                dbConnection.Transaction(username, password, 10);
    
    
            }
        }
    }
