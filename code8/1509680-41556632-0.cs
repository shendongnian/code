        public byte[] GetPrintContent(List<ConfirmationRequestNoticeViewModel> models)
        {
            PdfFileEditor pdfEditor = new PdfFileEditor();
            
            MemoryStream[] inputStreams = new MemoryStream[models.Count];
            MemoryStream fileStream = new MemoryStream(); ;
            using (MemoryStream outputStream = new MemoryStream())
            {
                for (int i = 0; i < models.Count; i++)
                {
                    ConfirmationRequestNoticeViewModel model = models[i];
                    byte[] fileContent = _dataService.GetPrintContent(model.ConfirmationRequestId);
                    
                    fileStream = new MemoryStream(fileContent);
                    
                    inputStreams[i] = fileStream;
                    
                }
                bool success = pdfEditor.Concatenate(inputStreams, outputStream);
                byte[] data = outputStream.ToArray();
                fileStream.Dispose();
                return data;
            }
            
        }
