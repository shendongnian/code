            case TimeRangeEntityType:
                    object jsonstring;
                    entity.Resolution.TryGetValue("values", out jsonstring);
                    //Remove the first and last characters so that we get a proper json string
                    var WellformedJson = jsonstring.ToString().Substring(1, jsonstring.ToString().Length - 2);
                    JObject jobj = JObject.Parse(WellformedJson);
                    var startTime = (DateTime)jobj["start"];
                    var endTime = (DateTime)jobj["end"];
