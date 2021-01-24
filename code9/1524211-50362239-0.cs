    class Program
    {
        static void Main(string[] args)
        {
            ExecuteEmployeeSearch();
            Console.ReadLine();
        }
        static void ExecuteEmployeeSearch()
        {
            // mockup JSON that would be returned from API
            string sampleJson = "{\"results\":[" +
                "{\"employeename\":\"name1\",\"employeesupervisor\":\"supervisor1\"}," +
                "{\"employeename\":\"name2\",\"employeesupervisor\":\"supervisor1\"}," +
                "{\"employeename\":\"name3\",\"employeesupervisor\":[\"supervisor1\",\"supervisor2\"]}" +
                "]}";
            // Parse JSON into dynamic object, convenient!
            JObject results = JObject.Parse(sampleJson);
            // Process each employee
            foreach (var result in results["results"])
            {
                // this can be a string or null
                string employeeName = (string)result["employeename"];
                // this can be a string or array, how can we tell which it is
                JToken supervisor = result["employeesupervisor"];
                string supervisorName = "";
                if (supervisor is JValue)
                {
                    supervisorName = (string)supervisor;
                }
                else if (supervisor is JArray)
                {
                    // can pick one, or flatten array to a string
                    supervisorName = (string)((JArray)supervisor).First;
                }
                Console.WriteLine("Employee: {0}, Supervisor: {1}", employeeName, supervisorName);
            }
        }
    }
}
