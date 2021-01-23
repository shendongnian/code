        [HttpPost]
        public HttpResponseMessage AddImageToScene(long id, string type)
        {
            SceneHandler handler = null;
            try
            {
                var content = Request.Content;
