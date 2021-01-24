            try
            {
                // access JIRA using (parts of) your existing code
            }
            catch (WebException we)
            {
                var response = we.Response as HttpWebResponse;
                if (response != null && response.StatusCode == HttpStatusCode.Forbidden)
                {
                    // JIRA doesn't like your credentials
                }
            }
