        [JsonIgnore]
        public DateTime created_utc
        {
            get
            {
                var unix = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return unix.AddSeconds(this.created_utcUnix);
            }
            set
            {
                var unix = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                this.created_utcUnix = Convert.ToInt64((value - unix).TotalSeconds);
            }
        }
        
        [JsonProperty("created_utc")]
        public double created_utcUnix { get; set; }
