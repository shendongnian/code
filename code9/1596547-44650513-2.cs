        class Foo
        {
            [JsonConverter(typeof(UnixConvert))]
            public DateTime created_utc { set; get; }
        }
