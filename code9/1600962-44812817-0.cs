        // In whatever async method
        // Assuming actual file? Add applicable checks as well.
        var xml = File.ReadAllText(fullPath + "PRE_COMMIT_LA.UM.5.8_524f7fef-5b37-11e7-b4ee-f0921c133f10.xml");
        using (var client = new System.Net.Http.HttpClient())
        {
             var response = await client.PostAsXmlAsync("http://ctdsapi1:8100/api/SoftwareProductBuild", xml);
             if (!response.IsSuccessStatusCode)
             {
                 throw new InvalidUriException("Some error with details."));
             }
             Console.WriteLine("Printing DEV Pool Response\n");
             ...etc.
        }
