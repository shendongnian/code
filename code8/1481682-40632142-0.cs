            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
            //// CHECK THE FILE COUNT.
            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            {
                System.Web.HttpPostedFile hpf = hfc[iCnt];
                string Image = UploadDocuments.GetDocumentorfileUri(hpf);
                UploadDocuments.UploadDocumentsIntoData(Image, hpf.FileName, id);
            }
