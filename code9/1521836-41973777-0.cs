        protected void Page_Load(object sender, EventArgs e)
        {
            hfid.Value = "0";
            frmSubmit.Attributes.Add("onclick", "this.disabled = true; this.value = 'Loading ...'; " + ClientScript.GetPostBackEventReference(frmSubmit, null) + ";");
        }
    
     protected void frmSubmit_Click(object sender, EventArgs e)
        {
            //Remove following line, this is added just to test.
            System.Threading.Thread.Sleep(5000);
            if (Convert.ToInt32(hfid.Value) == 0)
            {
                // Code of insert
                // then I set hfid.value with newly created id
            }
        }
