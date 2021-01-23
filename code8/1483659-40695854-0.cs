    private void ApacheTest() {
       if (!File.Exists(HTTPD_PATH)) {
          amountdl.Text = "Apache Not Found! Installation Corrupt!";
          return;
       }
       amountdl.Text = "Apache Is Starting";       
       StartApacheServer();
       
       while (ApacheRunning() == false) {
          // spin
       }
       amountdl.Text = "Apache Started";
    }
