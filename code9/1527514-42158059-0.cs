            var jObj = JObject.Parse(jsonText); ;
            var jobs = jObj["data-mode"]["Jobs"];
            var result = jobs.OfType<JProperty>().Where((a,b)=>{
                int key = 0;
                return int.TryParse(a.Name,out key);
            }).Select<JProperty,Job>((jp,i) => {
                return new Job
                {
                    Id = jp.Value["id"].ToObject<string>(),
                    Desc = jp.Value["description"].ToObject<string>()
                };
            }).ToArray();
