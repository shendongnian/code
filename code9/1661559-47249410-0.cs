            [EnableQuery()]
            public IQueryable<ItemDTO> Get()
            {
                var rad = Math.PI / 180;
                var deg=180/Math.PI;
                return db.Items
                    .Select(i => new
                    {
                        i.Id,
                        x = i.Locations.Sum(t => Math.Cos(t.cX * rad) * Math.Cos(t.cY * rad)),
                        y = i.Locations.Sum(t => Math.Cos(t.cX * rad) * Math.Sin(t.cY * rad)),
                        z = i.Locations.Sum(t => Math.Sin(t.cX * rad)),
                        Count = i.Locations.Count()
                    })
                    .Select(i => new ItemDTO
                    {
                        Id = i.Id,
                        Latitude = Math.Atan2(i.z, Math.Sqrt(i.x * i.x + i.y * i.y)) * deg,
                        Longtitude = Math.Atan2(i.y, i.x) * deg
                    });
            }
