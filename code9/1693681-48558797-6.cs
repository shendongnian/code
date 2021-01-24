        private async void AddStudent()
        {
            var stream = //gets image stream...
            var p = new Student
            {
                FirstName = "Johdn",
                LastName = "Doe",
            };
            using (var client = new HttpClient())
            {
                var serializedStudent = JsonConvert.SerializeObject(p);
                var stringContent = new StringContent(serializedStudent, Encoding.UTF8, "application/json");
                var multipartContent = new MultipartFormDataContent();
                using (var mem = new MemoryStream())
                {
                    await stream.CopyToAsync(mem);
                    var byteContent = new ByteArrayContent(mem.ToArray());
                    multipartContent.Add(byteContent, "files", "my file");
                    multipartContent.Add(new StringContent(p.FirstName), "FirstName");
                    multipartContent.Add(new StringContent(p.LastName), "LastName");
                    var response = await client.PostAsync(URI, multipartContent);
                }
            }
        }
