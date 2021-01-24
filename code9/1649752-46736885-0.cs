                    using (var reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    var streamRead = reader.ReadToEnd();
                    reader.Close();
                    using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(streamRead)))
                    {
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        DccCoachRootobject dccObj = js.Deserialize<DccCoachRootobject>(streamRead);
                        coachId = dccObj.data.id_user.ToString();
                    }
                }
