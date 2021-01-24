    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    namespace WindowsApplication1
    {
        public partial class Form1 : Form
        {
           public Form1()
           {
             InitializeComponent();
            }
    private void button1_Click(object sender, EventArgs e)
    {
        string connetionString = null; 
        SqlConnection connection ; 
        SqlDataAdapter adapter ; 
        DataSet ds = new DataSet(); 
        int i = 0;
        connetionString = "Data Source=ServerName;Initial                                                                                                                                                                       
        Catalog=DatabaseName;User ID=UserName;Password=Password"; 
        connection = new SqlConnection(connetionString); 
        try 
          { 
           connection.Open();
           adapter=new SqlDataAdapter("Your SQL Statement Here", connection); 
           adapter.Fill(ds); 
           connection.Close(); 
           for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++) 
            { 
             MessageBox.Show (ds.Tables[0].Rows[i].ItemArray[1].ToString()); 
            } 
           } catch (Exception ex) 
              { 
                MessageBox.Show(ex.ToString()); 
              } 
      }
     }
    }
