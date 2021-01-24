    private void btnSend_Click(object sender, EventArgs e)
    {
         //Send To details
         string Phnumber = textBox1.Text;
         string message = textBox2.Text;
         //send From details
         string FromNumber = "9177677377";
         string password = "bbRvfrEbePyI/uGOqyyw9yeHlys=";
         string nickName = "Laxman";
         WhatsApp wap = new WhatsApp(FromNumber, password, nickName, false, false);
         wap.OnConnectSuccess += () =>
             {
                 MessageBox.Show("Connected to whatsapp SuccessFully...");
                 wap.OnLoginSuccess += (PhoneNumber, data) =>
                 {
                     MessageBox.Show("Enterned");
                     wap.SendMessage(Phnumber, message);
                     MessageBox.Show("Message Sent Successfully...");
                 };
                 wap.OnLoginFailed += (data) =>
                 {
                     MessageBox.Show(data);
                     MessageBox.Show("Yes Failed login : {0}", data);
                 };
                 wap.Login();
             };
         wap.OnConnectFailed += (ex) =>
             {
                 MessageBox.Show("Conncetion Failure");
             };
         wap.Connect();
     }
