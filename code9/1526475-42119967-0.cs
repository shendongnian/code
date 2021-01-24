        [HttpGet]
        public ActionResult ShowPDF()
        {
            try
            {
                MemoryStream ms = new MemoryStream(GetPDF().ToArray());
                FileStreamResult filestream = new FileStreamResult(ms, "application/pdf");
                return filestream;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
