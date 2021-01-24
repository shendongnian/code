    public class Program
    {
        public static void Main(string[] args)
        {
            var jobs = GetDiceJobsAsync(Program.ResultCallBack).Result;
            Console.WriteLine($"\nAll {jobs.Count} jobs displayed");
            Console.ReadLine();
        }
        private static async Task<List<DiceApiJob>> GetDiceJobsAsync(Action<DiceApiJobWrapper> callBack = null)
        {
            var jobs = new List<DiceApiJob>();
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://service.dice.com");
            var nextUrl = "/api/rest/jobsearch/v1/simple.json?skill=ruby";
            do
            {
                await httpClient.GetAsync(nextUrl)
                    .ContinueWith(async (jobSearchTask) =>
                    {
                        var response = await jobSearchTask;
                        if (response.IsSuccessStatusCode)
                        {
                            string jsonString = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<DiceApiJobWrapper>(jsonString);
                            if (result != null)
                            {
                                // Build the full list to return later after the loop.
                                if (result.DiceApiJobs.Any())
                                    jobs.AddRange(result.DiceApiJobs.ToList());
                                // Run the callback method, passing the current page of data from the API.
                                if (callBack != null)
                                    callBack(result);
                                // Get the URL for the next page
                                nextUrl = (result.nextUrl != null) ? result.nextUrl : string.Empty;
                            }
                        }
                        else
                        {
                            // End loop if we get an error response.
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
