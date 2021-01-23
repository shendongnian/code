    public class YourClass
    {
    TextBox txtName; 
    TextBox txtTel;
    TextBox txtMobile;
    TextBox txtAddress;
    private void txtenable (Boolean txtenable, TextBox txtName, TextBox txtTel, TextBox txtMobile, TextBox txtAddress)
     {
     if(txtenable== false)
     {
         txtName.Enabled = false;
         txtTel.Enabled = false;
         txtMobile.Enabled = false;
         txtAddress.Enabled = false;
      }
      else
      {
          txtName.Enabled = true;
          txtTel.Enabled = true;
          txtMobile.Enabled = true;
          txtAddress.Enabled = true;
      }
    }
    
    
