    using System;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
           public Form1()
           {
               InitializeComponent();
           }
           int rowsaffected;
           public bool RemoveFromDatabase(int id)
           {
               try
               {
                   using (SqlConnection con = new SqlConnection(/*Connection string goes here*/))
                   {
                       using (SqlCommand com = new SqlCommand("DELETE FROM Speler WHERE id = '" + id + "'", con))
                       {
                           rowsaffected = com.ExecuteNonQuery();
                           return true;
                       }
                   }
               }
               catch (SqlException)
               {
                   MessageBox.Show("Something went wrong while removing the item");
                   return false;
               }
            
           }
        
           private void button1_Click(object sender, EventArgs e)
           {
            
               bool feedback = RemoveFromDatabase(Convert.ToInt16(listbox.Items.IndexOf(id)));
               if (rowsaffected == 1)
               {
                   //The item was deleted
               }else
               {
                //There is no item with this specific id
               }
            
            }
        }
   
    }
