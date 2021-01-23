    var client = new WebClient();
    while (i < 255)
    {
        try
        {
            byte[] result = await client.DownloadDataTask(new Uri("http://" + myIPNet + "." + i + ":1400/status/topology"));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        pbSearch.Value = i++;
    }
    /* Now we have all IPs */
    /* Reset progressBar */
    pbSearch.Value = 0;
    /* Enable Button  */
    btnGetAll.IsEnabled = true;
