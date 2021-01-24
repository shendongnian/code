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
    
    namespace Tmpz
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
                    DataTable dtb2 = new DataTable();
                    dtb2 = GetAddressInfo(dtb2);
                    dtb = GenerateBankStatement(dtb);
                    reportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rpd = new ReportDataSource("DataSet1", dtb);
                    ReportDataSource rpd2 = new ReportDataSource("DataSet2", dtb2);
                    reportViewer1.LocalReport.DataSources.Add(rpd);
                    reportViewer1.LocalReport.DataSources.Add(rpd2);
                    reportViewer1.RefreshReport();
                }
            }
    
            private DataTable GetAddressInfo(DataTable dt)
            {
                using (SqlConnection cn = new SqlConnection(constring))
                {
                    try
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select fullname as [fullname], accountNo as [accountNo], ccy as [ccy] from account_info where accountNo = '" + accountNo1.Text + "'", cn);
                        da.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                return dt;
            }
    
            private DataTable GenerateBankStatement(DataTable dt)
            {
                using (SqlConnection cn = new SqlConnection(constring))
                {
                    try
                    {
                        string dateF = Convert.ToDateTime(dateFrom.Text).ToString("dd-MM-yyyy");
                        string dateT = Convert.ToDateTime(dateTo.Text).ToString("dd-MM-yyyy");
                        // SqlDataAdapter da = new SqlDataAdapter("SELECT account_info.fullname as [fullname], account_info.accountNo as [accountNo], account_info.ccy as [ccy], account_info.address as [address] , transactions.id as [id], transactions.transaction_desc as [transaction_desc], transactions.credit as [credit], transactions.debit as [debit], transactions.balance as [balance], transactions.transaction_date as [transaction_date] FROM  transactions CROSS JOIN account_info WHERE(transactions.accountNo1 = '" + accountNo1.Text + "') AND(transactions.transaction_date BETWEEN '" + dateF + "' AND '" + dateT + "')", cn);
                        SqlDataAdapter da = new SqlDataAdapter("select id as [id], transaction_desc as [transaction_desc], credit as [credit], debit as [debit], balance as [balance], transaction_date as [transaction_date] from transactions where accountNo1 = '" + accountNo1.Text + "' and transaction_date between '"+ dateF + "' and '"+ dateT + "'", cn);
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
