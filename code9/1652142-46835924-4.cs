    [TestMethod]
    public void TestJsonToPocoAndGetNames()
    {
        const string Json = @"
            {
            ""cr_response"": {
                ""details"": [{
                    ""name"": ""Req"",
                    ""fields"": [{
                            ""value"": ""Prj0\r\nPrj1"",
                            ""name"": ""Project""
                        },
                        {
                            ""value"": ""October 13, 2017 14:18"",
                            ""name"": ""Submitted""
                        },
                        {
                            ""value"": ""John"",
                            ""name"": ""Rec Name""
                        }
                    ]
                }],
                ""cr_metadata"": {}
            }
        }
        ";
    
        var settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
        var response = JsonConvert.DeserializeObject<RootJsonObject>(Json, settings);
    
        var names = new List<string>();
        foreach (var detail in response.CrResponse.Details)
        {
            names.Add(detail.Name);
    
            foreach (var field in detail.Fields)
            {
                names.Add(field.Name);
            }
        }
    
        Assert.AreEqual(
            "Req, Project, Submitted, Rec Name",
            string.Join(", ", names.ToArray()));
    }
