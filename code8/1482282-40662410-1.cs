        [HttpPost]
        public void Attach()
        {
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase fileContent = Request.Files[file];
                Stream stream = fileContent.InputStream;
                string fileName = Path.GetFileName(file);
                string path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                using(var fileStream = System.IO.File.Create(path))
                {
                    stream.CopyTo(fileStream);
                }
            }
        }
