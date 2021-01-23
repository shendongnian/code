        if (!string.IsNullOrEmpty(requestNumber) && requestNumber.Contains("CMC") && HTML[1] != null && HTML[1] == htmlPage)
                {
                    //do page rotation
                    document.SetPageSize(PageSize.A4.Rotate());
                    document.NewPage();
                     Storage.rotationPage = "true";
                    hw.Parse(new StringReader(htmlPage));
                    
                }
                else
                {
                    document.SetPageSize(PageSize.A4);
                    document.NewPage();
                     Storage.rotationPage = "false";
                    hw.Parse(new StringReader(htmlPage));
                    
                }
