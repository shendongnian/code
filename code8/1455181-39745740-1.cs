    public static async Task CheckSite(string url, int id) {
        try {
            using (var db = new PlaceDBContext())
            using (var client = new HttpClient(new HttpClientHandler() {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            })) {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
                using (var response = await client.GetAsync(url))
                using (var content = response.Content) {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                    var rd = db.RootDomains.Find(id);
                    string result = await content.ReadAsStringAsync();
                    if (result != null && result.Length >= 50) {
                        Console.WriteLine("fine");
                        rd.LastCheckOnline = true;
                    } else {
                        Console.WriteLine("There was empty or short result");
                        rd.LastCheckOnline = false;
                    }
                    db.SaveChanges();
                    semaphore.Release();
                }
            }
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            using (var db = new PlaceDBContext()) {
                var rd = db.RootDomains.Find(id);
                rd.LastCheckOnline = false;
                db.SaveChanges();
                semaphore.Release();
            }
        }
    }
