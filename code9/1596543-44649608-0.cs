    [JsonIgnore]
        public DateTime created_utcCustom
        {
            get
            {
                var unix = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return unix.AddSeconds(this.created_utc);
            }
            set
            {
                var unix = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                this.created_utc = Convert.ToInt64((value - unix).TotalSeconds);
            }
        }
        
        [JsonProperty("created_utc")]
        public double created_utc { get; set; }
