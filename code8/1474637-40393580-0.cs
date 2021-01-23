    class Result
    {
      [JsonConverter(typeof(StringEnumConverter))]
      public EnumType EnumProperty { get; set; }
      *****other properties goes here****
    }
