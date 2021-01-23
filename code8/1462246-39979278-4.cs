     protected void Page_Load(object sender, EventArgs e)
     {
        if (Session["enable"] == false){
           txtenable(false);
        }else{
          txtenable(true);
        }
     } 
    private void txtenable (Boolean txtenable)
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
     
