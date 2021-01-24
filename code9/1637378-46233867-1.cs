        [HttpGet("/StatusCode/{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            string statusmessage = "";
            switch (statusCode)
            {
                case 400:
                    statusmessage = "Bad request: The request cannot be fulfilled due to bad syntax";
                    break;
                case 403:
                    statusmessage = "Forbidden";
                    break;
    //all codes here...
                default:
                    statusmessage = "That’s odd... Something we didn't expect happened";
                    break;
            }
            // return appropriate view 
            // or same view with different message, eg from ViewBag
        }
