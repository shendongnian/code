        using(HttpWebResponse response = request.GetResponse() as HttpWebResponse)     {
                using(StreamReader reader = new StreamReader(response.GetResponseStream())) {
                    //jsonVerisi adlı değişkene elde ettiği veriyi atıyoruz.
                    jsonVerisi = reader.ReadToEnd();
                    var searchResult = JsonConvert.DeserializeObject<JObject>(jsonVerisi);
                    if(searchResult != null) {
                        var itemListElement = searchResult["itemListElement"];
                        if(itemListElement != null) {
                            foreach(var item in itemListElement.ToList()) {
                                var result = item["result"];
                                var resultTypes = result != null && result["@type"].HasValues ? result["@type"].Values<string>().ToList() : null;
                                //Iterate through resultTypes to get the list of values
                                //e.g. for person
                                //var personType = resultTypes[1];
                            }
                        }
                    }
                }
            }
