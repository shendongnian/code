    public class Items
    {
        public Items() {
            this.element = new List<Element>();
        }
    
        public List<Element> element;
    }
    
    public class Element
    {
        public Element(int id) {
            this.Id = id;
        }
    
        public int Id;
    }
    [Route("api/common/JsonToXml")]
            [AcceptVerbs("POST")]
            public HttpResponseMessage JsonToXml(dynamic data)
            {
                Items list = new Items();
                list.element = new List<Element>();
    
                for (var ic = 0; ic < data.Items.Count; ic++)
                {
                    list.element.Add(new Element(Convert.ToInt32(data.Items[ic].id)));
                }
    
                XmlDocument xmlData = JsonConvert.DeserializeXmlNode(JsonConvert.SerializeObject(list), "Items");
    
                return Request.CreateResponse(HttpStatusCode.OK, xmlData.OuterXml);
            }
