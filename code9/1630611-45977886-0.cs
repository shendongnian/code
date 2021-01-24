     public class ApiLogHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var apiLogEntry = CreateApiLogEntryWithRequestData(request);
            if (request.Content != null)
            {
                request.Content.ReadAsStringAsync()
                   .ContinueWith(task =>
                   {
                       apiLogEntry.RequestContentBody = task.Result;
                   }, cancellationToken);
            }
            return base.SendAsync(request, cancellationToken)
                .ContinueWith(task =>
                {
                    var response = task.Result;
                    // Update the API log entry with response info
                    apiLogEntry.ResponseStatusCode = (int)response.StatusCode;
                    apiLogEntry.ResponseTimestamp = DateTime.Now;
                    if (response.Content != null)
                    {
                        apiLogEntry.ResponseContentBody = response.Content.ReadAsStringAsync().Result;
                        apiLogEntry.ResponseContentType = response.Content.Headers.ContentType.MediaType;
                        apiLogEntry.ResponseHeaders = SerializeHeaders(response.Content.Headers);
                    }
                    // TODO: Save the API log entry to the database
                    InsertAPILog(apiLogEntry);
                    return response;
                }, cancellationToken);
        }
        private ApiLogEntry CreateApiLogEntryWithRequestData(HttpRequestMessage request)
        {
            var context = ((HttpContextBase)request.Properties["MS_HttpContext"]);
            var routeData = request.GetRouteData();
            return new ApiLogEntry
            {
                Application = "[Logging]",
                User = context.User.Identity.Name,
                Machine = Environment.MachineName,
                RequestContentType = context.Request.ContentType,
                RequestRouteTemplate = routeData.Route.RouteTemplate,
                RequestRouteData = SerializeRouteData(routeData),
                RequestIpAddress = context.Request.UserHostAddress,
                RequestMethod = request.Method.Method,
                RequestHeaders = SerializeHeaders(request.Headers),
                RequestTimestamp = DateTime.Now,
                RequestUri = request.RequestUri.ToString()
            };
        }
        private string SerializeRouteData(IHttpRouteData routeData)
        {
            return JsonConvert.SerializeObject(routeData, Formatting.Indented);
        }
        private string SerializeHeaders(HttpHeaders headers)
        {
            var dict = new Dictionary<string, string>();
            foreach (var item in headers.ToList())
            {
                if (item.Value != null)
                {
                    var header = String.Empty;
                    foreach (var value in item.Value)
                    {
                        header += value + " ";
                    }
                    // Trim the trailing space and add item to the dictionary
                    header = header.TrimEnd(" ".ToCharArray());
                    dict.Add(item.Key, header);
                }
            }
            return JsonConvert.SerializeObject(dict, Formatting.Indented);
        }
        private void InsertAPILog(ApiLogEntry apiLogEntry)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["API_Logging"].ToString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("API_LoggingRequest", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Application", apiLogEntry.Application);
                    cmd.Parameters.AddWithValue("@User", apiLogEntry.User);
                    cmd.Parameters.AddWithValue("@Machine", apiLogEntry.Machine);
                    cmd.Parameters.AddWithValue("@RequestIpAddress", apiLogEntry.RequestIpAddress);
                    cmd.Parameters.AddWithValue("@RequestContentType", apiLogEntry.RequestContentType);
                    cmd.Parameters.AddWithValue("@RequestContentBody", apiLogEntry.RequestContentBody);
                    cmd.Parameters.AddWithValue("@RequestUri", apiLogEntry.RequestUri);
                    cmd.Parameters.AddWithValue("@RequestMethod", apiLogEntry.RequestMethod);
                    cmd.Parameters.AddWithValue("@RequestRouteTemplate", apiLogEntry.RequestRouteTemplate);
                    cmd.Parameters.AddWithValue("@RequestRouteData", apiLogEntry.RequestRouteData);
                    cmd.Parameters.AddWithValue("@RequestHeaders", apiLogEntry.RequestHeaders);
                    cmd.Parameters.AddWithValue("@RequestTimestamp", apiLogEntry.RequestTimestamp);
                    cmd.Parameters.AddWithValue("@ResponseContentType", apiLogEntry.ResponseContentBody);
                    cmd.Parameters.AddWithValue("@ResponseContentBody", apiLogEntry.ResponseContentBody);
                    cmd.Parameters.AddWithValue("@ResponseStatusCode", apiLogEntry.ResponseStatusCode);
                    cmd.Parameters.AddWithValue("@ResponseHeaders", apiLogEntry.ResponseHeaders);
                    cmd.Parameters.AddWithValue("@ResponseTimestamp", apiLogEntry.ResponseTimestamp);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
