    //Your third Form filled with billdata from second Form.
    public class ThirdForm : Form
    {       
       public ThirdForm(DataTable billData)
       {
          InitializeComponent();
          yourGrid.DataSource = billData;
       }
    }
    //Your secondform fetch the data and start the thirdform
    public class SecondForm : Form
    {        
       private void OnUpdateButton_Clicked(object sender, EventArgs e)
       {
          SqlConnection con = new SqlConnection(CS);
                                  con.Open();
          SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM POS WHERE Bill_No=@Billno", con);
          da.SelectCommand.Parameters.AddWithValue("@Billno", txt_EnterBillNoPOS.Text);
           DataTable result = new DataTable();
           da.Fill(result); //Fill your Table with data
           
           //Here you pass the data via Constructor
           var thirdForm = new ThirdForm(result);
           thirdForm.Show();
        }
    }
    
    //The firstform which starts your flow by activating secondform
    public class FirstForm : Form
    {   
        private void OnUpdateLastButton_Clicked(object sender, EventArgs e)
        {
           var childForm = new SecondForm();
           childForm.Show(); //Shows the second form
        }
    }
