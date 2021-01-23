    public partial class frmAccounts : OfficeForm
    {
     private void btn_edit_Click(object sender, EventArgs e)
     {
    	frmEditAccount ed = new frmEditAccount();
    	ed.EnableCustomStyle = true ;
    	DialogResult res =ed.ShowDialog();
    	if (res == System.Windows.Forms.DialogResult.OK)
            {
    		.....
    		....
    	}
     }
    }
