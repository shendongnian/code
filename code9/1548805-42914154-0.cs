    public struct GameObjectMetadata
    {
        public GameObjectMetadata(UnityEngine.Object value)
        {
            if (value == null)
                throw new ArgumentNullException();
            this.UnityType = value.GetType().ToString();
            var path = UnityEditor.AssetDatabase.GetAssetPath(value);
            var bundleName = UnityEditor.AssetImporter.GetAtPath(path).assetBundleName;
            var guid = UnityEditor.AssetDatabase.AssetPathToGUID(path);
            this.AssetBundle = bundleName;
            this.AssetFullPath = path;
            this.GUID = guid;
        }
        public UnityEngine.Object GetRealObject()
        {
            // I'm not a unity3d developer so I am not sure this is the correct method to call.
            return UnityEditor.AssetDatabase.LoadAssetAtPath(AssetFullPath, Type.GetType(UnityType));
        }
        public string AssetFullPath;
        public string AssetBundle;
        public string GUID;
        public string UnityType;
    }
    public class UnityObjectJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(UnityEngine.Object).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var metadata = serializer.Deserialize<GameObjectMetadata>(reader);
            return metadata.GetRealObject();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // WriteJson is never called when value == null.  Instead Json.NET calls writer.WriteNull() directly.
            var metadata = new GameObjectMetadata((UnityEngine.Object)value);
            serializer.Serialize(writer, metadata);
        }
    }
