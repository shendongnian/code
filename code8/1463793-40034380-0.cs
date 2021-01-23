     [Route("{lang}/documents")]
        public async Task PostDocument()
        {
            string dirPath = _appConfigurationManager.GetDocumentFolder();
            if (!Directory.Exists(dirPath))
            {
                DirectoryInfo createdir = Directory.CreateDirectory(dirPath);
            }
            if (Request.Content.IsMimeMultipartContent())
            {
                if (Request.Content.ReadAsStringAsync().Result.ToString().IndexOf("filename=\"\"") == -1)
                {
                    var streamProvider = new CustomMultipartFormDataStreamProvider(dirPath);
                    var result = await Request.Content.ReadAsMultipartAsync(streamProvider);
                    var fileEntity = new ViewModels.Common.FileDescViewModel();
                    foreach (var file in result.FileData)
                    {
                        fileEntity.FileName = file.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
                        fileEntity.Url = "~/" + fileEntity.FileName;                       
                    }
                    var jsonmodel = result.FormData["jsonData"].ToString().Replace("\"content\":\"\",", string.Empty);
                    if (jsonmodel == null)
                        throw new Exception();
                    var siteViewModel = JsonConvert.DeserializeObject<DocumentViewModel>(jsonmodel);
                    siteViewModel.Url = fileEntity.Url;                   
                    siteViewModel.Name = fileEntity.FileName;
                    AddDocumentDetails(siteViewModel);
                }
                else
                {
                    string jsonData = Request.Content.ReadAsStringAsync().Result.Replace("\"content\":\"\",", string.Empty);
                    jsonData = jsonData.Substring(jsonData.IndexOf('{'), jsonData.LastIndexOf('}') - jsonData.IndexOf('{') + 1);
                    var siteViewModel = JsonConvert.DeserializeObject<DocumentViewModel>(jsonData);
                    AddDocumentDetails(siteViewModel);
                }
            }
        }
