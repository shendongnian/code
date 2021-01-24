    using System.Windows.Forms;
    using System.Data.OleDb;
    
    private void PopualteComboBox()
    {
    //Here add your code to populate Dataset ds from the Database.
    
     DataTable dt = ds.Tables["[sheet1$]"];
    
     int i = 0;
    
     for (i = 0; i <= dt.Rows.Count -1; i++)
    
     {
    
         comboBox1.Items.Add(dt.Rows[i].ItemArray[0]);
    
     }
