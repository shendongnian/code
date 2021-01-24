            PriceModel value = JsonConvert.DeserializeObject<PriceModel>("{'Price': '1234,99'}", new JsonSerializerSettings
            {
                // tr culture separator is ","..
                Culture = new System.Globalization.CultureInfo("tr-TR")
            });
