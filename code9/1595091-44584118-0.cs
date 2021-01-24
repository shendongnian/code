        Random r = new Random((int)DateTime.Now.Ticks);
        var x = r.Next(100000, 999999);
        string s = x.ToString("000000");
        string UniqueFileName = "S" + s + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
        request.Resource = "api/BFormat/AddNewBFormat";
        request.Method = Method.POST;
        request.RequestFormat = DataFormat.Json;
        var body = new
        {
            UploadFileVM = new
            {
                BordereauxId = "",
                BFormatId = "",
                FileName = UniqueFileName,
                Filesize = 0,
                Path = @"c:\sdakdldas\"
            }
        };
        request.AddBody(body); //enter code herE
        var queryResult = client.Execute<ResponseData<Guid>>(request).Data;
        try
        {
            Assert.IsTrue(queryResult.ReturnData != null);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
