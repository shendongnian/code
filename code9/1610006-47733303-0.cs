    protected void Application_BeginRequest(object sender, EventArgs e)
    {
          string[] headers = { "Server", "X-AspNetMvc-Version" };
          if (!Response.HeadersWritten)
          {
            Response.AddOnSendingHeaders((c) =>
                {
                    if (c != null && c.Response != null && c.Response.Headers != null)
                    {
                        foreach (string header in headers)
                        {
                            if (c.Response.Headers[header] != null)
                            {
                                c.Response.Headers.Remove(header);
                            }
                        }
                    }
                });
            }
    }
