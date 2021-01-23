    [Authorize, HttpPost]
        private JsonResult ActionNAme(ModelClass modelObj, HttpPostedFileBase htmlFileTagName)
        {
            string code = "0x001";
            string message = "";
            try
            {
                // your process here
            }
            catch(Exception)
            {
                code = "0x000";
                message = ex.Message;
            }
            return new JsonResult()
            {
                Data = new
                {
                    code = code,
                    message = message
                }
            };
        }
