      [TestClass]
      public class UnitTest1
      {
        [TestMethod]
        public void TestMethod1()
        {
          using (Microsoft.QualityTools.Testing.Fakes.ShimsContext.Create())
          {
            int? usedPageSize = 0;
            var usedQ = string.Empty;
            var usedFields = string.Empty;
            var usedPageToken = string.Empty;
    
            Google.Apis.Drive.v3.Fakes.ShimFilesResource.ShimListRequest.AllInstances.PageSizeSetNullableOfInt32 =
              (request, i) => usedPageSize = i;
            Google.Apis.Drive.v3.Fakes.ShimFilesResource.ShimListRequest.AllInstances.QSetString = (request, s) => usedQ = s;
            Google.Apis.Drive.v3.Fakes.ShimDriveBaseServiceRequest<Google.Apis.Drive.v3.Data.FileList>.AllInstances
              .FieldsSetString = (request, s) => usedFields = s;
    
            Google.Apis.Drive.v3.Fakes.ShimFilesResource.ShimListRequest.AllInstances.PageTokenSetString = (request, s) => usedPageToken = s;
            Google.Apis.Requests.Fakes.ShimClientServiceRequest<Google.Apis.Drive.v3.Data.FileList>.AllInstances
                .ExecuteAsync =
              request =>
                Task.FromResult(
                  new FileList
                    {
                      ETag = "hello",
                      Files = new List<File> { new File { Name = "imafile" } },
                      IncompleteSearch = false,
                      Kind = "Somekind",
                      NextPageToken = null
                    });
    
            Google.Apis.Drive.v3.Fakes.ShimFilesResource.AllInstances.List = resource => (FilesResource.ListRequest)FormatterServices.GetUninitializedObject(typeof(FilesResource.ListRequest));
            Google.Apis.Drive.v3.Fakes.ShimDriveService.Constructor = service => { }; // do not init the class
            Google.Apis.Drive.v3.Fakes.ShimDriveService.AllInstances.FilesGet = service => (FilesResource)FormatterServices.GetUninitializedObject(typeof(FilesResource));
    
            var target = new Class1();
            var result = target.ReadFileList("parent", "token", 42).Result;
    
            Assert.AreEqual(42, usedPageSize);
            Assert.AreEqual("mimeType='application/vnd.google-apps.folder' and ('parent' in parents)", usedQ);
            Assert.AreEqual("nextPageToken, files(id, name)", usedFields);
            Assert.AreEqual("token", usedPageToken);
            Assert.AreEqual(1, result.Files.Count);
            Assert.AreEqual("imafile", result.Files[0].Name);
            Assert.AreEqual("hello", result.ETag);
            Assert.IsFalse(result.IncompleteSearch.Value);
            Assert.AreEqual("Somekind", result.Kind);
            Assert.IsNull(result.NextPageToken);
          }
        }
      }
