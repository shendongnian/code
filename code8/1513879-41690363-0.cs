    //The ChildForm is the Form you open on click the UpdateLastBill-Button
    public class MyChildForm : Form
    {
       public DataTable Result{get;private set;}
        
       private void OnBillNumberEntered(object sender, EventArgs e)
       {
          SqlConnection con = new SqlConnection(CS);
                                  con.Open();
          SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM POS WHERE Bill_No=@Billno", con);
          da.SelectCommand.Parameters.AddWithValue("@Billno", txt_EnterBillNoPOS.Text);
           da.Fill(Result); //Fill you Table-Property with data
           DialogResult = DialogResult.OK;
        }
    }
    
    //This is your Main-Form which contains the Grid
    public class MyMainForm : Form
    {   
        private void OnUpdateLastButton_Clicked(object sender, EventArgs e)
        {
           var childForm = new MyChildForm();
           if (childForm.ShowDialog() == Dialog.OK)
           {
              DataTable billData = childForm.Result;
              //Here you can add your new Data to Grid
           }
        }
    }
