    private TestClient testClient = new TestClient();
        public async Task<IHttpActionResult> GET(string fileName)
        {
            try
            {
                var result = await testClient.runbatchfile(Path.GetFileNameWithoutExtension(fileName));
                var resultDTO = JsonConvert.DeserializeObject<TestVariable>(result);
                return Json(resultDTO);
            }
            catch (Exception e)
            {
                var result = "Server is not running";
                return Ok(new { ErrorMessage = result });
            }
        }
