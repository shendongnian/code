        [HttpGet]
        public FileContentResult GetFile(string path)
        {
            VerifyAccessOrThrow(path);
            var fileName = "example";
            //We need to enclose the filename in double quotes for the mighty Firefox
            Response.AppendHeader("Content-Disposition", $"inline; filename=\"{fileName}\"");
            Response.ContentType = MimeMapping.GetMimeMapping(fileName);
            return File(fileContent, MimeMapping.GetMimeMapping(fileName));
        }
