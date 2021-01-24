	var json = "{\"0abc34m\": {\"time\": \"13 Mar 17, 4:50:02 PM\", \"pd\": \"oscar\"}}";
	dynamic d = JObject.Parse(json);
	var values = (d.Properties() as IEnumerable<JProperty>)
      .First()
      .Value as JObject;
	var time = DateTime.Parse(((values.Properties() as IEnumerable<JProperty>)
      .First()
      .Value as JValue).Value as string);
	var pd = ((values.Properties() as IEnumerable<JProperty>)
      .Skip(1)
      .First()
      .Value as JValue).Value as string;
    Console.WriteLine(time);
    Console.WriteLine(pd);
