    namespace AudAPIApp
    { 
        public class GoogleAPI
        {
            public GetReportsResponse googleRpt;
            public void GenerateReport()
            {
                try
                {
                       //code that gets all the data. This all works in a console app I made. My challenge is making it work in MVC. 
                    var response = batchRequest.Execute();
                    googleRpt = response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
