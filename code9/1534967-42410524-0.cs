    private void SubmitData()
    {
    try
    {
         string user = tbUsername.Text;
         string pass = tbPassword.Text;
         string url = "--my_php_url--";
         WebClient webclient = new WebClient();
         NameValueCollection formData = new NameValueCollection();
         formData["user_name"] = user;
         formData["password"] = pass;
         byte[] responseBytes = webclient.UploadValues(url, "POST", formData);
         string responsefromserver = Encoding.UTF8.GetString(responseBytes);
         MessageBox.Show(responsefromserver);
         webclient.Dispose();
    }
    catch (Exception e )
    {
    MessageBox.Show("Error :" + e.Message);
    }
