     httpClient.GetString(new Uri(url),
        (response) =>
        {
            // Raised when the download completes
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //idProcess = Newtonsoft.Json.Linq.JObject.Parse(response.Data);
                StartCoroutine(WaitForResponce(responce));
            }
            else
            {
                idProcess = null;
            }
        });
