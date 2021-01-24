        using(HttpWebResponse response = request.GetResponse() as HttpWebResponse) {
                using(StreamReader reader = new StreamReader(response.GetResponseStream())) {
                    //jsonVerisi adlı değişkene elde ettiği veriyi atıyoruz.
                    jsonVerisi = reader.ReadToEnd();
                    //Deserialize
                    var searchResult = JsonConvert.DeserializeObject<SearchResult>(jsonVerisi);
                    //Now you could get the needed value as below
                    if(searchResult != null) {
                        foreach(var item in searchResult.itemListElement) {
                            var resultTypes = item.result != null ? item.result.type : null;
                            //Iterate through resultTypes to get the list of values
                            //e.g. for person
                            //var personType = resultTypes[1];
                        }
                    }
                }
            }
