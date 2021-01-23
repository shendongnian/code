            var LogDate = new DateTime(2016, 9, 20, 22, 2, 0, DateTimeKind.Utc);
            string JsonDate = JsonConvert.SerializeObject(LogDate, new JsonSerializerSettings {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            });
            Console.WriteLine(JsonDate);
            Console.ReadLine();
