            var jArray = JArray.Parse(json);
            var matchedElements = jArray.Cast<JObject>().ToDictionary(item => item.Properties().FirstOrDefault().Name, item => item.Properties().FirstOrDefault().Value.Value<string>());
            if (matchedElements.Where(kv => kv.Key.Contains("txtSocialContentsImage")).Count() > 1 
                && matchedElements.Any(x => x.Key == "txtSocialContentsImageValue_3"))
            {
                return matchedElements["txtSocialContentsImageValue_3"];
            }
