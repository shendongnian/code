       News student = new News
                {
                    Id = Guid.NewGuid(),
                    Subject = "wfwf",
                    ViewerCounter = 1, // removed the "" (string)
                    MainContent = "fsdsd", // renamed from "Content"
                    SubmitDateTime = DateTime.Now,
                    ModifiedDateTime = DateTime.Now,
                    PublisherName = "sdaadasd",
                    PictureAddress = "adfafsd",
                    TypeOfNews = "adsadaad"
                };
                WebClient Proxy1 = new WebClient();
                Proxy1.Headers["Content-type"] = "application/json";
                MemoryStream ms = new MemoryStream();
                DataContractJsonSerializer serializerToUplaod = new DataContractJsonSerializer(typeof(News));
                serializerToUplaod.WriteObject(ms, student);
                 Proxy1.UploadData("http://localhost:47026/NewsRepository.svc/AddNews", "POST", ms.ToArray());
