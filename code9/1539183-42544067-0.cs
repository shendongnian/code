    private void btnParse_Click(object sender, EventArgs e)
    {
      string strFilePath = txtOpenFile.Text;
      string serialNo = txtSerialNumber.Text;
      string groupNo = txtGroupNumber.Text;
      ArrayList data = new ArrayList();
    
      if (txtOpenFile.Text != "")
        {
          DDRParsingService.DDRParserService client = new DDRParsingService.DDRParserService();
    
          // Call the Web Service
         data =  client.PVTLog(serialNo, groupNo, strFilePath);
          // I get the error : Cannot implicitly convert type 'object[]' to 'System.Collections.ArrayList'          
        }
    
    }
