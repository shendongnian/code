            Version(x => x.upsize_ts, map => 
            {
                map.Column(c => 
                {
                    c.SqlType("timestamp");
                    c.NotNullable(false);
                });
                map.Type(new BinaryBlobType());
                map.Generated(VersionGeneration.Always);
                map.UnsavedValue(null);
            });
