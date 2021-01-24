     JObject rss = new JObject(
            new JProperty("query",
                new JObject(
                    new JProperty("aoi",
                        new JObject(
                            new JProperty("type", "Polygon"),
                            new JProperty("coordinates",
                                new JArray(
                                    new JArray(
                                        new JArray(
                                            new JValue(-122.62664794921874),
                                            new JValue(38.81403111409755)
                                            ),
                                        new JArray(
                                            new JValue(-122.62664794921874),
                                            new JValue(38.81403111409755)
                                            )
                                    ) as Object
                            ))
                            ))
                    ))
            );			
