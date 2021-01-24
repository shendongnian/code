    protected void frmSubmit_Click(object sender, EventArgs e)
    {
       if(Session["isProcessingForm"])
       {
           return;
       }
       Session["isProcessingForm"] = true;
       if(Convert.ToInt32(hfid.value) == 0)
       {
           // Code of insert
           // then I set hfid.value with newly created id
       }
       //Once form is processed
       Session["isProcessingForm"] = false;
    }
