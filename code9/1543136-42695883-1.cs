    async Task<JsonResult> External(int p)
        {
            var formData = await GetJObjectFromFormData();
            if (formData == null)
                throw new ArgumentNullException("form data");
            string query = formData["query"].ToObject<string>();
            Debug.WriteLine("query : " + query);
            Dictionary<string, string[]> faceting = formData["faceting"]
                .ToDictionary<JToken, string, string[]>(
                (j) =>
                {
                    return ((JProperty)j).Name;
                },
                (j) =>
                {
                    return j.First.ToObject<string[]>();
                });
            foreach (var key in faceting.Keys)
            {
                Debug.WriteLine("key : {0}, values : {1}", key, string.Join(",", faceting[key]));
            }
            return Json("");
            
        }
