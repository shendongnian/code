        [HttpPost]
        public ActionResult Upload()
        {
            IFormFile fileFromRequest = Request.Form.Files.First();
            string myFileName = fileFromRequest.Name;
            // some code
            return Ok();
        }
