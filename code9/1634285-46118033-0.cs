           if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<Rootobject>(result);
                //No idea what you want to do with this line as there is no MetaData property on the root object
                obj.MetaData = MetaData;
            }
