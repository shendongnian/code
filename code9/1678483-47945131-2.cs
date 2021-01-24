    public interface IJobModel
    {
        string ClientBaseURL { get; set; }
        string UserEmail { get; set; }
        ExportType Type { get; set; }
        List<IItemModel> Items { get; set; }
    }
    public interface IItemModel
    {
        string Id { get; set; }
        string ImageSize { get; set; }
        string ImagePpi { get; set; }
        List<ICamSettings> CamSettings { get; set; }
    }
    public interface ICamSettings
    {
        string FileName { get; set; }
    }
    public enum ExportType
    {
        Thumbnails,
    }
    public class ThumbnailJobModel : IJobModel
    {
        [JsonProperty("clientBaseURL")]
        public string ClientBaseURL { get; set; }
        [JsonProperty("userEmail")]
        public string UserEmail { get; set; }
        [JsonProperty("type")]
        [JsonConverter(typeof(ExportTypeConverter))]
        public ExportType Type { get; set; }
        [JsonProperty("items", ItemConverterType = typeof(ConcreteConverter<IItemModel, Item>))]
        public List<IItemModel> Items { get; set; }
        public ThumbnailJobModel()
        {
            Type = ExportType.Thumbnails;
            Items = new List<IItemModel>();
        }
        public class Item : IItemModel
        {
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("imageSize")]
            public string ImageSize { get; set; }
            [JsonProperty("imagePpi")]
            public string ImagePpi { get; set; }
            [JsonProperty("shoots", ItemConverterType = typeof(ConcreteConverter<ICamSettings, ShootSettings>))]
            public List<ICamSettings> CamSettings { get; set; }
            public Item()
            {
                CamSettings = new List<ICamSettings>();
            }
        }
        public class ShootSettings : ICamSettings
        {
            [JsonProperty("orientation")]
            [JsonConverter(typeof(StrictStringEnumConverter))]
            public Orientation Orientation { get; set; }
            [JsonProperty("clothShape")]
            [JsonConverter(typeof(StrictStringEnumConverter))]
            public Shape Shape { get; set; }
            [JsonProperty("fileName")]
            public string FileName { get; set; }
            public ShootSettings()
            {
                Orientation = Orientation.Perspective;
                Shape = Shape.Folded;
                FileName = null;
            }
        }
        public enum Orientation
        {
            Perspective = 0,
            Oblique = 1,
            Front = 2,
            Back = 3,
            Left = 4,
            Right = 5,
            Up = 6,
            Down = 7
        }
        public enum Shape
        {
            Folded = 0,
            Hanger = 1,
            Mannequin = 2
        }
        public class ConcreteConverter<IInterface, TConcrete> : JsonConverter where TConcrete : IInterface
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(IInterface) == objectType;
            }
            public override object ReadJson(JsonReader reader,
             Type objectType, object existingValue, JsonSerializer serializer)
            {
                return serializer.Deserialize<TConcrete>(reader);
            }
            public override bool CanWrite { get { return false; } }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
        public class ExportTypeConverter : StringEnumConverter
        {
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                reader.Skip(); // Skip anything at the current reader's position.
                return ExportType.Thumbnails;
            }
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(ExportType);
            }
        }
        public class StrictStringEnumConverter : StringEnumConverter
        {
            public StrictStringEnumConverter() { this.AllowIntegerValues = false; }
        }
        public static void HandleDeserializationError(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs errorArgs)
        {
            errorArgs.ErrorContext.Handled = true;
            var currentObj = errorArgs.CurrentObject as ShootSettings;
            if (currentObj == null) return;
            currentObj.Orientation = Orientation.Perspective;
            currentObj.Shape = Shape.Folded;
        }
    }
