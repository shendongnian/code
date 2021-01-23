        public async void FirstMethod()
        {
           
            var entities = db.entities.ToList();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            foreach (var entity in entities)
            {
             
                string area= entity.address + " " + entity.city + " " + land;
                var address = String.Format("https://maps.googleapis.com/maps/api/geocode/json?key=AIzaSyArOWaWq_xXjAm68DlFFFqoxK7Z_ggYk9E&address=" + area);
                response = await client.GetAsync(address);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync();
                    var jObject = Newtonsoft.Json.Linq.JObject.Parse(data.Result);
                    string status = jObject["status"].ToObject<string>();
                    if (status == "OK")
                    {
                        var geometryLocation = jObject["results"][0]["geometry"]["location"];
                        string lat = geometryLocation["lat"].ToObject<string>();
                        string lon = geometryLocation["lng"].ToObject<string>();
                        SecondMethod(lat+" "+lon ,entity);
                    }
                }
            }
        }
        public void SecondMethod(string preometry, model entity)
        {
            entity.Geometry = System.Data.Entity.Spatial.DbGeometry.FromText("POINT(" + preometry + ")");
            string[] latLon = preometry.Split(' ');
            entity.Latitude = Decimal.Parse(latLon[0].Replace(".", ","));
            entity.Longitude = Decimal.Parse(latLon[1].Replace(".", ","));
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
