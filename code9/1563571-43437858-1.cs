    class ParseOneManga {
        public async Task<string> GetMangaDescriptionPageAsync(string detailUrl) {
            using (var client = new HttpClient()) {
                    string s = await client.GetStringAsync(detailUrl);
                    return s;
                }
            }
        }
    }
  
