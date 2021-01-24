      public static string TransformJSON(string json, IWebElement chartElem)
        {
            string fixedJson = "";
            if (chartElem.GetAttribute("id") == "EPAChart")
            {
                dynamic obj = JsonConvert.DeserializeObject<EPAObservationCountOriginal>(json);
                List<EPAObservationCountFixed> fixedObject = new List<EPAObservationCountFixed>();
                for (int i = 0; i < obj.Categories.Length; i++)
                {
                    fixedObject.Add(new EPAObservationCountFixed() { category = obj.Categories[i], data = obj.Data[i] });
                }
                fixedJson = JsonConvert.SerializeObject(fixedObject);
            }
            return fixedJson;
        }
        #endregion methods
        #region Class objects representing graphs
        public class EPAObservationCountFixed
        {
            public string category { get; set; }
            public string data { get; set; }
        }
        public class EPAObservationCountOriginal
        {
            public string[] Categories { get; set; }
            public string[] Data { get; set; }
        }
