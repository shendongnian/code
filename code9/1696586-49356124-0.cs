    static async Task yourMethod(HttpClient client)
            {
                var obj = await GetSecret(client);
                Console.WriteLine(obj);
            }
