    using System;
    using System.Windows.Forms;
    using System.Data.OleDb;
    using System.IO;
    
    namespace MS_AccessAddNewRecord_cs
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void addRecordButton_Click(object sender, EventArgs e)
            {
                var ops = new Operations();
                var newId = 0;
                if (ops.AddNewRow(companyTextBox.Text, contactNameTextBox.Text, contactTitleTextBox.Text, ref newId))
                {
                    newIdentifierTextBox.Text = $"{newId}";
                }
                else
                {
                    MessageBox.Show($"{ops.Exception.Message}");
                }
            }
        }
        /// <summary>
        /// This class should be in a separate class file, I placed it here for easy of learning
        /// </summary>
        public class Operations
        {
            private OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder
            {
                Provider = "Microsoft.ACE.OLEDB.12.0",
                DataSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb")
            };
    
            private Exception mExceptiom;
            public Exception Exception
            {
                get
                {
                    return mExceptiom;
                }
            }
            /// <summary>
            /// Add a new record, upon success return the new primary key for the record in pIdentifier parameter
            /// </summary>
            /// <param name="pName"></param>
            /// <param name="pContactName"></param>
            /// <param name="pContactTitle"></param>
            /// <param name="pIdentfier"></param>
            /// <returns></returns>
            public bool AddNewRow(string pName, string pContactName, string pContactTitle, ref int pIdentfier)
            {
                bool Success = true;
    
                try
                {
                    using (OleDbConnection cn = new OleDbConnection { ConnectionString = Builder.ConnectionString })
                    {
                        using (OleDbCommand cmd = new OleDbCommand { Connection = cn })
                        {
                            cmd.CommandText = "INSERT INTO Customers (CompanyName,ContactName, ContactTitle) " + 
                                                              "Values(@CompanyName,@ContactName, @ContactTitle)";
    
                            cmd.Parameters.AddWithValue("@CompanyName", pName);
                            cmd.Parameters.AddWithValue("@ContactName", pContactName);
                            cmd.Parameters.AddWithValue("@ContactTitle", pContactTitle);
    
                            cn.Open();
    
                            int Affected = cmd.ExecuteNonQuery();
    
                            if (Affected == 1)
                            {
                                cmd.CommandText = "Select @@Identity";
                                pIdentfier = Convert.ToInt32(cmd.ExecuteScalar());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Success = false;
                    mExceptiom = ex;
                }
    
                return Success;
    
            }
        }
    }
