      public void SenRequestByEmail()
        {
		string ReqId="CT001";
            try
            {
                using (var stream = new MemoryStream())
                {
                    //methodto bind details to your model
                    var res = dealerService.BindReqToPrint(ReqId);
                   //_PrintActivationRequest is your View name here and res is the object of the model you are using at your view
                    ViewAsPdf pdf = new ViewAsPdf("_PrintActivationRequest", res) { FileName = "DeviceActivationRequest.pdf" };
                    //convert the pdf into array of bytes 
                    byte[] bytes = pdf.BuildPdf(this.ControllerContext);
                    string fileName = string.Format("DeviceActivationRequest_{0}.pdf", DateTime.Now.ToString("dd_MMM_yy_hh:mm"));
                    SendDeviceActivationRequest(new MemoryStream(bytes), fileName );
                }
            }
            catch (Exception ex)
            {
            }
                
        }
