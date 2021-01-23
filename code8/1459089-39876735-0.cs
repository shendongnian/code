    public static class DllHelper
    {
       [System.Runtime.InteropServices.DllImport("Dll1.dll")]
       public static extern int func1();
    }
    private void btnExec_Click(object sender, EventArgs e)
    {
       try
       {
           DllHelper.func1();
       }
       catch (Exception ex)
       {
          Console.WriteLine(ex.Message);
       }
    }
