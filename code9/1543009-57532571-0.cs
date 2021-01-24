            var request = response.RequestMessage;
            (response.Content ?? new StringContent("")).ReadAsStringAsync().ContinueWith(x =>
            {
                string ip = string.Empty;
                string hstname = string.Empty;
                var ctx = request.Properties["MS_HttpContext"] as HttpContextWrapper;
                if (logInDb)
                {
                    CommandLogWebApiResponse cmd = new CommandLogWebApiResponse()
                    {
                        Guid = request.GetCorrelationId().ToString(),
                        RequestTime = ctx.Timestamp
                    };
                    cmd.ResponseTime = DateTime.Now;
                    cmd.ResponseData = x.Result;
                    try
                    {
                        var result = manLogWebApiResponse.ExecuteCommand(cmd);
                        //result.Value.Wait();
                    }
                    catch (Exception ex)
                    {
                        var t = ex;
                    }
                }
                else if (storeInReq)
                {
                    if (request.Properties.ContainsKey("responseJson"))
                    {
                        request.Properties["responsejson"] = x.Result;
                    }
                    else
                    {
                        request.Properties.Add("responsejson", x.Result);
                    }
                }
                //string message = string.Format("{4:yyyy-MM-dd HH:mm:ss} {4} {0} response [{1}] - {2}", request.GetCorrelationId(), response.StatusCode, x.Result, DateTime.Now, Username(request));
                //System.Diagnostics.Trace.WriteLine(message, "Info");
                //Logger.Info("{3:yyyy-MM-dd HH:mm:ss} {4} {0} response [{1}] - {2}", request.GetCorrelationId(), response.StatusCode, x.Result, DateTime.Now, Username(request));
            });
        }
