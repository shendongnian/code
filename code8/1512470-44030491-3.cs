    internal IActionResult CreateResponse(int code, object content = null)
        {
            Type t = content?.GetType();
            bool textContent = t == typeof(string) || t == typeof(bool);
            //
            JsonSerializerSettings dateFormatSettings = new JsonSerializerSettings
            {
                
                DateFormatString = myDateFormat
            };
            string bodyContent = content == null || string.IsNullOrWhiteSpace(content + "")
                        ? null
                        : textContent
                            ? content + ""
                            : JsonConvert.SerializeObject(content, dateFormatSettings);
            
            ObjectResult or = base.StatusCode(code, bodyContent);
            string mediaType = 
                        !textContent
                            ? "application/json"
                            : "text/plain";
            or.ContentTypes.Add(new MediaTypeHeaderValue(mediaType));
            return or;
        }
