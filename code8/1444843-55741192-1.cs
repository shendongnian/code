            [Route("home/UploadFile")]
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");
            var client = new HttpClient();
            byte[] data;
            using (var br = new BinaryReader(file.OpenReadStream()))
                data = br.ReadBytes((int)file.OpenReadStream().Length);
            ByteArrayContent bytes = new ByteArrayContent(data);
            MultipartFormDataContent multiContent = new MultipartFormDataContent
            {
                { bytes, "file", file.FileName }
            };
            var result = client.PostAsync("http://localhost:2821/api/upload/" + file.FileName, multiContent).Result;
            return RedirectToAction("file");
        }
