        public string DataAsJson
        {
            get
            {
                var serializeObject = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue }.Serialize(YourListHere);
                return serializeObject;
            }
        }
