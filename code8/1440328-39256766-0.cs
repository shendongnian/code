    public class Parent
    {
        public Parent() { this.Props = new List<string>(); }
        [JsonProperty("id")]
        public int ParentId { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonIgnore]
        public List<string> Props { get; set; }
        [JsonExtensionData]
        JObject extensionData; // JObject implements IDictionary<string, JToken> and preserves document order.
        [OnSerializing]
        void OnSerializing(StreamingContext ctx)
        {
            VariablePropertyListExtensions.OnSerializing(Props, ref extensionData, false);
        }
        [OnSerialized]
        void OnSerialized(StreamingContext ctx)
        {
            VariablePropertyListExtensions.OnSerialized(Props, ref extensionData, false);
        }
        [OnDeserializing]
        void OnDeserializing(StreamingContext ctx)
        {
            VariablePropertyListExtensions.OnDeserializing(Props, ref extensionData, false);
        }
        [OnDeserialized]
        void OnDeserialized(StreamingContext ctx)
        {
            if (Props == null)
                Props = new List<string>();
            VariablePropertyListExtensions.OnDeserialized(Props, ref extensionData, false);
        }
    }
    public static class VariablePropertyListExtensions
    {
        public const string Prefix = "prop_";
        readonly static Regex regex;
        static VariablePropertyListExtensions()
        {
            regex = new Regex("^" + Prefix + @"\d+" + "$", RegexOptions.CultureInvariant | RegexOptions.Compiled); // Add  | RegexOptions.IgnoreCase if required
        }
        public static void OnSerializing<TDictionary>(IList<string> props, ref TDictionary extensionData, bool keepUnknownProperties) where TDictionary : class, IDictionary<string, JToken>, new()
        {
            Debug.Assert(keepUnknownProperties || (extensionData == null || extensionData.Count == 0));
            // Add the prop_ properties.
            if (props == null || props.Count < 1)
                return;
            extensionData = extensionData ?? new TDictionary();
            for (int i = 0; i < props.Count; i++)
                extensionData.Add(Prefix + (i + 1).ToString(NumberFormatInfo.InvariantInfo), (JValue)props[i]);
        }
        internal static void OnSerialized<TDictionary>(IList<string> props, ref TDictionary extensionData, bool keepUnknownProperties) where TDictionary : class, IDictionary<string, JToken>, new()
        {
            // Remove the prop_ properties.
            if (extensionData == null)
                return;
            foreach (var name in extensionData.Keys.Where(k => regex.IsMatch(k)).ToList())
                extensionData.Remove(name);
            // null out extension data if no longer needed
            if (!keepUnknownProperties || extensionData.Count == 0)
                extensionData = null;
        }
        internal static void OnDeserializing<TDictionary>(IList<string> props, ref TDictionary extensionData, bool keepUnknownProperties) where TDictionary : class, IDictionary<string, JToken>, new()
        {
            Debug.Assert(keepUnknownProperties || (extensionData == null || extensionData.Count == 0));
        }
        internal static void OnDeserialized<TDictionary>(IList<string> props, ref TDictionary extensionData, bool keepUnknownProperties) where TDictionary : class, IDictionary<string, JToken>, new()
        {
            props.Clear();
            if (extensionData == null)
                return;
            foreach (var item in extensionData.Where(i => regex.IsMatch(i.Key)).ToList())
            {
                props.Add(item.Value.ToObject<string>());
                extensionData.Remove(item.Key);
            }
            // null out extension data if no longer needed
            if (!keepUnknownProperties || extensionData.Count == 0)
                extensionData = null;
        }
    }
