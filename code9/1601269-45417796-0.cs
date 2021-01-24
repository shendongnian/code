        [HttpPost]
        public async Task<JsonResult> log(string requestId)
        {
            var url = ApiBaseAdress + string.Format("/api/runs/log/{0}", requestId);
            List<Log> logs = new List<Log>();
            var response = await HttpClientSingleton.Instance.GetAsync(url);
            
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            logs = JsonConvert.DeserializeObject<List<Log>>(result);
            
            return Json(logs);
        }
