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
            object value = null;
            if(bodyContent != null)
            {
                string mediaType = !textContent
                            ? "application/json"
                            : "text/plain";
                Encoding utf8 = Encoding.UTF8;
                value = new StringContent(bodyContent, utf8, mediaType);
            };
            return base.StatusCode(code, value);
        }
