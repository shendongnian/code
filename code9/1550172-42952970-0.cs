    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Configuration;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Windows.Forms;
    
    
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    
    
        protected void btnRegister_Click(object sender, EventArgs e)
            {
                string connString = WebConfigurationManager.ConnectionStrings["csPAD"].ConnectionString;
    
                SqlConnection myConnection = new SqlConnection(connString);
                if (Page.IsValid)
                {
                    string Study = rbStudy.SelectedValue;
    
                    string sqlQuery = "INSERT INTO Registratie ([Firstname], [middlename], [Lastname], [Dateofbirth], [Study], [Email]) VALUES (@Firstname,@middlename,@Lastname,@Dateofbirth,@Study,@Email)";
                   SqlCommand cmd = new SqlCommand(sqlQuery, myConnection)
                    {
    
                        cmd.Parameters.AddWithValue("@Firstname", txtFirstname.Text);
                        if (txtmiddlename.Text == "")
                        {
                            cmd.Parameters.AddWithValue("@middlename", "");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@middlename", txtmiddlename.Text);
                        }
                        cmd.Parameters.AddWithValue("@Lastname", txtLastname.Text);
                        cmd.Parameters.AddWithValue("@Dateofbirth", Dateofbirth);
                        cmd.Parameters.AddWithValue("@Study", Study);
                        if (txtEmail.Text == "")
                        {
                            cmd.Parameters.AddWithValue("@Email", "");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        }        
                        myConnection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show(rows + " rows affected!");
                        myConnection.Close();                             
                    }
                }
                else
                { 
                    lblNotification.Text = "Everything is required.";
                }
            }
    
    }
