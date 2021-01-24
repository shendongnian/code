    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    namespace Migratable {
        [JsonConverter(typeof(MigratableConverter))]
        public interface IMigratable {
        }
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
        public class MigratableAttribute : Attribute {
            public readonly Guid Id;
            public MigratableAttribute(string guid) {
                Id = Guid.Parse(guid);
            }
        }
        public class MigratableConverter : JsonConverter {
            [ThreadStatic]
            static bool writeDisabled = false;
            [ThreadStatic]
            static bool readDisabled = false;
            public override bool CanRead => !readDisabled;
            public override bool CanWrite => !writeDisabled;
            public override bool CanConvert(Type objectType) => typeof(IMigratable).IsAssignableFrom(objectType);
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
                try {
                    writeDisabled = true;
                    if (null == value) {
                        writer.WriteValue(value);
                    } else {
                        var jObject = JObject.FromObject(value);
                        jObject.Add("$typeId", MigratableTypes.GetTypeId(value.GetType()));
                        jObject.WriteTo(writer);
                    }
                } finally {
                    writeDisabled = false;
                }
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
                try {
                    readDisabled = true;
                    var jObject = JToken.ReadFrom(reader) as JObject;
                    if (null == jObject) return null;
                    var typeId = (Guid)jObject.GetValue("$typeId");
                    var type = MigratableTypes.GetType(typeId);
                    return JsonConvert.DeserializeObject(jObject.ToString(), type);
                } finally {
                    readDisabled = false;
                }
            }
        }
        internal static class MigratableTypes {
            static readonly Dictionary<Guid, Type> Data = new Dictionary<Guid, Type>();
            static MigratableTypes() {
                foreach (var type in GetIMigratableTypes()) {
                    CheckIMigratableRules(type);
                    Data[GetTypeId(type)] = type;
                }
            }
            static IEnumerable<Type> GetIMigratableTypes() {
                return AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes()
                    .Where(t => typeof(IMigratable).IsAssignableFrom(t))
                    .Where(t => !t.IsAbstract));
            }
            static void CheckIMigratableRules(Type type) {
                // Check for duplicate IMigratable identifiers
                var id = GetTypeId(type);
                if (Data.ContainsKey(id))
                    throw new Exception($"Duplicate '{nameof(MigratableAttribute)}' value found on types '{type.FullName}' and '{Data[id].FullName}'.");
                // [DataContract] attribute is required, on EVERY class, not just base classes
                if (type.GetCustomAttributes(typeof(DataContractAttribute), false).Length == 0)
                    throw new Exception($"'{nameof(IMigratable)}' objects are required to use the '[DataContract]' attribute. Class: '{type.FullName}'.");
                // Collect information about [DataMember] attributes on all fields and properties including inherited and private.
                var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
                var fields = type.GetFields(bindingFlags).Where(f => null != f.GetCustomAttribute(typeof(DataMemberAttribute))).ToArray();
                var properties = type.GetProperties(bindingFlags).Where(p => null != p.GetCustomAttribute(typeof(DataMemberAttribute))).ToArray();
                var members = fields.Cast<MemberInfo>().Concat(properties.Cast<MemberInfo>())
                    .Select(m => new {
                        Member = m,
                        DataMemberAttribute = (DataMemberAttribute)m.GetCustomAttribute(typeof(DataMemberAttribute))
                    }).ToArray();
                // Check that DataMember names are explicitly set eg [DataMember(Name = "xx")]
                var noName = members.FirstOrDefault(m => !m.DataMemberAttribute.IsNameSetExplicitly);
                if (null != noName) {
                    var message = $"'{nameof(IMigratable)}' objects are required to set DataMember names explicitly. Class: '{type.FullName}', Field: '{noName.Member.Name}'.";
                    throw new Exception(message);
                }
                // Check that DataMember names are not accidentally duplicated.
                var duplicateName = members.GroupBy(m => m.DataMemberAttribute.Name).FirstOrDefault(g => g.Count() > 1);
                if (null != duplicateName) {
                    throw new Exception($"Duplicate DataMemberName '{duplicateName.Key}' found on class '{type.FullName}'.");
                }
            }
            public static Type GetType(Guid typeId) {
                return Data[typeId];
            }
            public static Guid GetTypeId(Type type) {
                var a = type.GetCustomAttributes(typeof(MigratableAttribute), false)
                    .Cast<MigratableAttribute>()
                    .FirstOrDefault();
                if (null == a)
                    throw new Exception($"'{nameof(MigratableAttribute)}' attribute does not exist on type '{type.FullName}'.");
                if (Guid.Empty == a.Id)
                    throw new Exception($"'{nameof(MigratableAttribute)}' attribute was not set to a proper value on type '{type.FullName}'.");
                return a.Id;
            }
        }
    }
