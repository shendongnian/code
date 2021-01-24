    namespace YOUR_NAME_SPACE
    {
      public class jira
      {
        public static string createTicket(string url, string data)
        {
            try
            {
                var client = new System.Net.Http.HttpClient();
                string base64Credentials = GetEncodedCredentials();
                var header = new AuthenticationHeaderValue("Basic", base64Credentials);
                client.DefaultRequestHeaders.Authorization = header;
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var result = client.PostAsync(url, content).Result;
                var response = result.Content.ReadAsStringAsync().Result;
                // You can call putIssue if you want
                return response;
            }
            catch (System.Net.WebException ex)
            {
                Console.WriteLine("Exception Occurred" + " : {0}", ex.Message);
                throw;
            }
        }
        private static string GetEncodedCredentials()
        {
            string mergedCredentials = string.Format("{0}:{1}", "LOGIN", "PASSWD");
            byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
            return Convert.ToBase64String(byteCredentials);
        }
        public static string jiraSerialise(string project, string summary, string description, string issutype, string author)
        {
            JObject valuesToJson =
               new JObject(
                   new JProperty("fields",
                       new JObject(
                           new JProperty("project",
                                new JObject(new JProperty("key", project))),
                           new JProperty("summary", summary),
                           new JProperty("description", description),
                           new JProperty("issuetype",
                                new JObject(new JProperty("name", issutype))),
                           new JProperty("assignee",
                                new JObject(new JProperty("name", author))))));
            return valuesToJson.ToString();
        }
        public static string putSerialize(string key, string value)
        {
            JObject valueToJson =
                new JObject(
                    new JProperty(key, value));
            return valueToJson.ToString();
        }
        public static string putIssue(string response, string author, System.Net.Http.HttpClient client)
        {
            JObject jsonResponse = JObject.Parse(response);
            Dictionary<string, string> dictResponse = jsonResponse.ToObject<Dictionary<string, string>>();
            string issueUrl = dictResponse.Last().Value;
            string issueAssignee = issueUrl + "/assignee";
            var authorContent = new StringContent(author, Encoding.UTF8, "application/json");
            var authorResult = client.PutAsync(issueAssignee, authorContent).Result;
            var authorResponse = authorResult.Content.ReadAsStringAsync().Result;
            Console.WriteLine(authorResponse);
            return authorResponse;
        }
      }
     }
