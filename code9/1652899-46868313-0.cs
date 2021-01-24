    var json =
                    " {\"OperationId\":\"N0004\",\"Generic_Object_That_Will_Change_According_ToThe_GateWay\":{\"Sale_id\":1000,\"CodUser\":\"1000040\"}}";
    
                JsonSchema paypalschema = new JsonSchema();
                paypalschema.Type = JsonSchemaType.Object;
                paypalschema.Properties = new Dictionary<string, JsonSchema>
                {
                    {"OperationId", new JsonSchema {Type = JsonSchemaType.String}},
                    {
                        "Generic_Object_That_Will_Change_According_ToThe_GateWay",
                        new JsonSchema {Type = JsonSchemaType.Object,Properties = new Dictionary<string, JsonSchema>
                        {
                            {"Sale_id", new JsonSchema {Type = JsonSchemaType.Integer}},
                            {"CodUser", new JsonSchema {Type = JsonSchemaType.String}},
                                                    }}                   
                    }
                };
    
            JObject requestObject = JObject.Parse( json);
                bool valid = requestObject.IsValid(paypalschema);
                if (valid)
                {
                    //create your GatewayObject here 
                }
                //else check another gateway object 
