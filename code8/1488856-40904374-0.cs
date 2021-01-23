        [TestMethod]
        public async Task Upload_document_should_upload_document_and_return_dto()
        {
            var goalId = Guid.NewGuid();
            var file = new Services.DTO.FileUploadDto { Id = goalId, Name = "dummy.txt", Uri = "path/to/file" };
            this.goalService.Setup(m => m.UploadDocument(It.IsAny<Guid>(), It.IsAny<IFormFile>(), It.IsAny<string>())).ReturnsAsync(file);
            //**This is the interesting bit**
            this.controller.ControllerContext = this.RequestWithFile();
            var result = await controller.UploadGoalDocument(goalId);
            Assert.IsNotNull(result);
            Assert.AreEqual(file.Id, result.Data.Id);
            Assert.AreEqual(file.Name, result.Data.Name);
            Assert.AreEqual(file.Uri, result.Data.Uri);
        }
        //Add the file in the underlying request object.
        private ControllerContext RequestWithFile()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers.Add("Content-Type", "multipart/form-data");
            var file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.txt");
            httpContext.Request.Form = new FormCollection(new Dictionary<string, StringValues>(), new FormFileCollection { file });
            var actx = new ActionContext(httpContext, new RouteData(), new ControllerActionDescriptor());
            return new ControllerContext(actx);
        }
