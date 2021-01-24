    public static bool InsertAllFotos(tTodo ttodo, List<Fotos> fotos, List<string> blob)
            {
                //var test2 = blob[0].blob_data.Bytes;
                List<tSyndFoto> tFotos = new List<tSyndFoto>();
                foreach(var foto in fotos)
                {
                    tSyndFoto tFoto = new tSyndFoto();
                    tFoto.id_synd_dossier = ttodo.id_gebouw;
                    tFoto.omschrijving = foto.Omschrijving;
                    tFoto.id_todo = ttodo.id_todo;
                    tFotos.Add(tFoto);
                }
                
                JObject json = new JObject();
    
                json.Add("fotos", JsonConvert.SerializeObject(tFotos));
    
                //tBlob tmpBlob = new tBlob();
                //tmpBlob.blob_data = new Binary();
                //tmpBlob.blob_data.Bytes = new byte[0];
                // tmpBlob.blob_data.Bytes =  blob[0].blob_data.Bytes;
                //var lijst = new List<tBlob>();
                //lijst.Add(tmpBlob);
                json.Add("blobs", JsonConvert.SerializeObject(blob));
                //json.Add("blobs", null);
                //string test = json.ToString();
    
                //var jon2 = JsonConvert.DeserializeObject(blob[0].blob_data.Bytes.ToString());
                var test = json.ToString();
               test =  test.Replace("\"[", "[");
               test =  test.Replace("]\"", "]");
               // test = test.Replace("\\n", "");
                test = test.Replace("\\", "");
               
                Debug.WriteLine(test);
                var content = new StringContent(test, Encoding.UTF8, "application/json");
    
             
                var resp = client.PostAsync("InsertFotos", content);
    
    
                if (resp.Result.IsSuccessStatusCode)
                {
    
                    var repStr = resp.Result.Content.ReadAsStringAsync();
    
    
                    JObject jo = JObject.Parse(repStr.Result.ToString());
                    return jo.SelectToken("InsertFotosResult", false).ToObject<bool>();
    
    
    
                }
                
                return false;
            }
