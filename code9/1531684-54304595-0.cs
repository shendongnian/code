        public string HealthCheck(WaitForStatus waitForStatus = WaitForStatus.Red, bool logResults = false)
        {
            string message = string.Empty;
            var client = new ElasticClient(new Uri("http://localhost:9200"));
            var response = client.ClusterHealth(new ClusterHealthRequest() { WaitForStatus = waitForStatus });
            var healthColor = response.Status.ToString().ToLower();
            // this will give you the color code of the elastic search server health.
            if (response.IsValid)
            {
                switch (healthColor)
                {
                    case "green":
                        message = "ElasticSearch Server health check returned [GREEN]";
                        break;
                    case "yellow":
                        message = "ElasticSearch Server health check returned [YELLOW] (yellow is normal for single node clusters) ";
                        break;
                    default: // Includes "red"
                        message = "ElasticSearch Server health check returned [{response.Status.ToString().ToUpper()}]";
                        break;
                }
            }
            else
                message = response.ApiCall.OriginalException.Message;
            return message;
        }
