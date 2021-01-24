        private string Serialize(List<NameDTO> _nameDetials, List<ValDTO> _valDetials)
        {
            JArray jChildArray = new JArray();
            for (int i = 0; i < Math.Max(_nameDetials.Count, _valDetials.Count) / 4; i++)
            {
                var jChildObject = new JObject();
                for (int j = 0; j < 4; j++)
                    jChildObject.Add(_nameDetials[i * 4 + j].Name, _valDetials[i * 4 + j].Val);
                jChildArray.Add(jChildObject);
            }
            return JsonConvert.SerializeObject(jChildArray);
        }
