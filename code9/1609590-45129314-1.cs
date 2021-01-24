    catch (WebException wex)
    {
        try
        {
            if (wex.Response != null)
            {
                Console.WriteLine("ERROR (web exception, response generated): " + Environment.NewLine +
                                  new StreamReader(wex.Response.GetResponseStream()).ReadToEnd());
            }
            else
            {
                Console.WriteLine("ERROR (web exception, NO RESPONSE): " + wex.Message + wex.StackTrace);
            }
            Console.WriteLine("Error - Call Details=" + GetCallDetails(uri));
        }
        catch (Exception bob)
        {
            // Ignore exceptions here
        }
    }
