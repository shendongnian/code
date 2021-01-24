    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Microsoft.Reporting.WinForms;
    
    namespace TwpZ
    {
        public partial class BalanceSheet : Form
        {
            string constring = ConfigurationManager.ConnectionStrings["ConnData"].ConnectionString;
            public BalanceSheet()
            {
                InitializeComponent();
            }
    
            private void BalanceSheet_Load(object sender, EventArgs e)
            {
                
            }
    
            private void reportViewer1_Load(object sender, EventArgs e)
            {
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (accountNo1.Text == "")
                {
                    MessageBox.Show("Please Enter Account Number");
                }
                else
                {
                    DataTable dtb = new DataTable();
                    dtb = GenerateBankStatement(dtb);
                    reportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rpd = new ReportDataSource("DataSet1", dtb);
                    reportViewer1.LocalReport.DataSources.Add(rpd);
                    reportViewer1.RefreshReport();
                }
            }
    
            private DataTable GenerateBankStatement(DataTable dt)
            {
                using (SqlConnection cn = new SqlConnection(constring))
                {
                    try
                    {
                        string dateF = Convert.ToDateTime(dateFrom.Text).ToString("dd-MM-yyyy");
                        string dateT = Convert.ToDateTime(dateTo.Text).ToString("dd-MM-yyyy");
                        SqlDataAdapter da = new SqlDataAdapter("SELECT [id] as id, [transaction_desc] as transaction_desc,[credit] as credit, [debit] as debit, [balance] as balance, [transaction_date] as transaction_date FROM transactions WHERE(accountNo1 = '" + accountNo1.Text + "') AND(transaction_date BETWEEN '" + dateF + "' AND '" + dateT + "')", cn);
                        //SqlDataAdapter da = new SqlDataAdapter("SELECT [id] as id, [transaction_desc] as transaction_desc,[credit] as credit, [debit] as debit, [balance] as balance, [transaction_date] as transaction_date FROM transactions WHERE(accountNo1 = '" + accountNo1.Text + "')", cn);
                        da.Fill(dt);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                return dt;
            }
        }
    }
