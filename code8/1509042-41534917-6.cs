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
              if (listBox1.Items.Contains(id.ToString()))
              {
                  MessageBox.Show("Exists");
                  listBox1.Items.Remove(id.ToString());
                  try
                  {
                      SqlConnection con = new SqlConnection(/*Connection string goes here*/);
                      con.Open();
                      SqlCommand com = new SqlCommand("DELETE FROM Speler WHERE id = '" + id + "'", con);
                      com.ExecuteNonQuery();
                      con.Close();
                      return true;
                  }
                  catch (SqlException)
                  {
                      MessageBox.Show("Something went wrong while removing the item");
                      return false;
                }
              }
              else
              {
                  MessageBox.Show("Wasn't found!");
                  return false;
             }
 
          }
          private void button1_Click(object sender, EventArgs e)
          {
              if(RemoveFromDatabase(Convert.ToInt16(textBox1.Text))){
                 MessageBox.Show("Deleted");
              }else{
                 MessageBox.Show("Not Found or something went wrong");
              }             
          }
      }
    }
