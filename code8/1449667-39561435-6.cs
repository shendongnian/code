    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ShortPath
    {
        class Program
        {
            static void Main(string[] args)
            {
     // assuming you have loaded your CSVs into a list of string
                List<string> csvLines = new List<string>()
                {
                    "Sydney,Dubai,1",
                    "Dubai,Venice,2",
                    "Venice,Rio,3",
                    "Venice,Sydney,1",
                    "Sydney,Rio,7"
                };
    
    
    
                // lets convert the list of string into list or route
                var routes = new List<Route>();
                csvLines.ForEach(s =>
                {
                    // split by ,
                    string[] pieces = s.Split(',');
    
                    // ensure travel time is a number
                    decimal travelTime = 0;
                    decimal.TryParse(pieces[2], out travelTime);
    
                    // convert string to route object
                    routes.Add(new Route()
                    {
                        From = pieces[0],
                        To = pieces[1],
                        TravelTime = travelTime
                    });
                });
    
                // once all the data in place - the rest is easy.
                // lets assume our FROM is sydne
                string selectedFrom = "Sydney";
    
                // no lets find all the routes from sydney to every other place
                // listing the shortes route first
                // the "Where" clause allows us to filter by the selected from
                // the order by clause allows us to order by travel time
                var desiredRoutes = routes.Where(route => route.From == selectedFrom).OrderBy(route => route.TravelTime).ToList();
    
                // the output template allows us to format all outputs
                // the numbers in culry bracers such as {0} {1}...etc are placeholderst that get replaced with actul values
                // {0} = index number
                // {1} = To
                // {2} = duration
                // {3} = From
                // "To 1: Dubai, Smallest Path Length: 1, Path: Sydney, Dubai.";/
                string outputTemplate = "To {0}: {1}, Smallest Path Length: {2}, Path: {3}, {1}.";
    
    
                Console.WriteLine("Selected Country: '{0}'.", selectedFrom);
    
                // look through each selected route
                for(int index = 0; index < desiredRoutes.Count; index++)
                {
                    // ensure you access to the route variable in the current instance of the loop
                    var route = desiredRoutes[index];
    
                    // write all outputs
                    // (index + 1) allows our counter to start from 1 instead of 0
                    Console.WriteLine(outputTemplate, (index + 1), route.To, route.TravelTime, route.From);
                }
    
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
