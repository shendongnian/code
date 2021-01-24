                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                 var response = client.GetAsync(baseAddress + "api/values").Result;
                var result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);*/
                Console.ReadLine();
            }
        }
    }
