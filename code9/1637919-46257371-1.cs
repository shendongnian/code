            GlobalWeatherSoapClient gwsc = new GlobalWeatherSoapClient("GlobalWeatherSoap12");
            var response = gwsc.GetCitiesByCountry("Chad");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(NewDataSet));
            var dataSet = xmlSerializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(response))) as NewDataSet;
            if (dataSet != null)
            {
                var cities = dataSet.Table.Select(x => x.City).ToList();
            }
