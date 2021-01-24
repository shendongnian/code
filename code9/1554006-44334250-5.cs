        public async Task<string> Post([FromContent]Stream contentStream)
        {
            using (StreamReader reader = new StreamReader(contentStream, Encoding.UTF8))
            {
                var str = reader.ReadToEnd();
                Console.WriteLine(str);
            }
            return "OK";
        }
