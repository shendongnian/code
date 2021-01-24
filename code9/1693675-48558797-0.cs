        private async void AddStudent(object sender, EventArgs e)
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
                    multipartContent.Add(stringContent, "student");
                    var response = await client.PostAsync("http://localhost:54522/api/Student", multipartContent);
                }
            }
        }
