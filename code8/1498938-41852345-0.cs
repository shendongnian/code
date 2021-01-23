        [HttpGet]
        public HttpResponseMessage Export()
        {
            using (var wb = new XLWorkbook())
            using (MemoryStream ms = new MemoryStream())
            {
                wb.Worksheets.Add("sample").FirstCell().SetValue("some value");
                wb.SaveAs(ms);
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(ms.GetBuffer());
                result.Content.Headers.ContentLength = ms.Length;
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "sample.xlsx"
                };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                return result;
            }
        }
