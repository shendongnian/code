    public class OuterConverter :
            JsonCreationConverter<OuterItems>
    {
            protected override OuterItems Create(Type objectType, JObject jObject)
            {
                OuterItems outeritems =
                    new OuterItems();
                var properties = jObject.Properties().ToList();
                outeritems.InnerItems = GetInnerItems((object)properties[0].Value);
                return outeritems;
            }
            // Need to iterate through list so creating a custom object
            private List<List<InnerItems>> GetInnerItems(object propertyValue)
            {
                string sinneritems = "";
                object inneritems = propertyValue;
                sinneritems = String.Format("{0}", inneritems);
                sinneritems = sinneritems.Insert(1, "{ \"Items\": [");
                sinneritems = sinneritems.Substring(1, sinneritems.Length - 1);
                sinneritems = sinneritems.Remove(sinneritems.Length - 1);
                sinneritems += "]}";
                dynamic results = JObject.Parse(sinneritems);
                List<List<InnerItems>> innerItemsList = new List<List<InnerItems>>();
                List<InnerItems> linnerItems = new List<InnerItems>();
                foreach (var items in results.Items)
                {
                    foreach (var item in items)
                    {
                        string sItem = String.Format("{0}", item);
                        InnerItems ninneritems = Newtonsoft.Json.JsonConvert.DeserializeObject<InnerItems>(sItem);
                        linnerItems.Add(ninneritems);
                    }
                    innerItemsList.Add(linnerItems);
                }
                return innerItemsList;
            }
    }
