    public class PivHelper
    {
        static readonly AsyncLazy<Piv> _lazyPiv = new AsyncLazy<Piv>(() => GetPivAsync());
    
        public Task<Piv> PivTask => _lazyPiv.Value;
    
        static Task<Piv> GetPivAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync("http://some-web-site.com");
    
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<Piv>();
                    }
                    else
                    {
                        return new Piv();
                    }
                }
            }
            catch (Exception ex)
            {
                return new Piv();
            }
        }
    }
    
    public class Piv
    {
        public string Header { get; set; }
        public string Footer { get; set; }
        public string Styles { get; set; }
        public string Scripts { get; set; }
    }
