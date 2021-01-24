    if (msg.IsSuccessStatusCode)
        {
            using (var stream = await msg.Content.ReadAsStreamAsync())
            {
                using (var streamReader = new StreamReader(stream))
                {
                    var str = await streamReader.ReadToEndAsync();
                    var obj = JsonConvert.DeserializeObject<IEnumerable<BookDTO>>(str);
                    return obj;
                }
            }
        }
