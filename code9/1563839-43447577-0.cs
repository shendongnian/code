    public class Program
    {
        public static void Main(string[] args)
        {
            var jobs = GetDiceJobsAsync(Program.ResultCallBack).Result;
            Console.WriteLine($"\nAll {jobs.Count} jobs displayed");
            Console.ReadLine();
        }
        private static async Task<List<DiceApiJob>> GetDiceJobsAsync(Action<DiceApiJobWrapper> callBack)
        {
            HttpClient httpClient = new HttpClient();
            var jobs = new List<DiceApiJob>();
            httpClient.BaseAddress = new Uri("http://service.dice.com");
            var nextUrl = "/api/rest/jobsearch/v1/simple.json?skill=ruby";
            do
            {
                await httpClient.GetAsync(nextUrl)
                    .ContinueWith(async (jobSearchTask) =>
                    {
                        var response = jobSearchTask.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            string jsonString = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<DiceApiJobWrapper>(jsonString);
                            if (result != null)
                            {
                                if (result.DiceApiJobs.Any())
                                    jobs.AddRange(result.DiceApiJobs.ToList());
                                callBack(result);
                                nextUrl = (result.nextUrl != null) ? result.nextUrl : string.Empty;
                            }
                        }
                        else
                        {
                            nextUrl = string.Empty;
                        }
                    });                
            } while (!string.IsNullOrEmpty(nextUrl));
            return jobs;
        }
        private static void ResultCallBack(DiceApiJobWrapper jobSearchResult)
        {
            if (jobSearchResult != null && jobSearchResult.count > 0)
            {
                Console.WriteLine($"\nDisplaying jobs {jobSearchResult.firstDocument} to {jobSearchResult.lastDocument}");
                foreach (var job in jobSearchResult.DiceApiJobs)
                {
                    Console.WriteLine(job.jobTitle);
                    Console.WriteLine(job.company);
                }
            }
        }
    }
