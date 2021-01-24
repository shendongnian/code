        public async Task<string> Post([FromContent]HttpContent content)
        {
            var str = await content.ReadAsStringAsync();
            Console.WriteLine(str);
            return str;
        }
