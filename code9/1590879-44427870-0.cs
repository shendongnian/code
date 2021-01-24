    public partial class YourDialog:Form
    {
      public string Result = "";
      public YourDialog()
      {// add all the controls you need with the necessary handlers
       //add the OK button with an "On Click handler"
      }
     
      private void OK_Button_Click(object sender, EventArgs e)
      {
        //set the Result value according to your controls
        this.hide();// will explain in the main form
      }
   
    }
  
    // in your main form
    private string GetUserResult()
    {
      YourDialog NewDialog = new YourDialog(); 
      NewDialog.ShowDialog();//that's why you only have to hide it and not close it before getting the result
      
      string Result = NewDialog.Result;
      NewDialog.Close();  
      return Result;
    }
