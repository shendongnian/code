    private object _lockObj = new object();
    protected void frmSubmit_Click(object sender, EventArgs e)
    {
        // Here we lock code. When someone else will try to access to this code
        // or in your case double clicked button it will wait until _lockObj
        // is set to free.
        Lock(_lockObj)
        {
            if(Convert.ToInt32(hfid.value) == 0)
            {
            // Code of insert
            // then I set hfid.value with newly created id
            }
        }
    }
