        public JsonResult UploadScreenshot(string imageData)
        {
            string fileNameWitPath = Server.MapPath("~/test.png");
            imageData = imageData.Substring(imageData.IndexOf(',') + 1);
            try
            {
                using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(imageData);
                        bw.Write(data);
                        bw.Close();
                    }
                }
            }
            catch
            {
                return Json(false);
            }
            return Json(true);
        }
