    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    namespace Demo
    {
        public class Team
        {
            public string id { get; set; }
            public Driver driver { get; set; }
            public Driver codriver { get; set; }
        }
        public class Driver
        {
            public Team parentTeam { get; set; }
            public string driverId { get; set; }
        }
        class Program
        {
            static void Main()
            {
                var original = new List<Team>
                {
                    new Team {id = "T1", driver = new Driver { driverId = "D2" }, codriver = new Driver { driverId = "C1"} },
                    new Team {id = "T2", driver = new Driver { driverId = "D1"} }
                };
                var cloned = Cloner.Clone(original);
                // Change original to prove that clone is not referencing it.
                original[0].codriver.driverId = "changed";
                Console.WriteLine(cloned[0].codriver.driverId); // Should be C1
            }
        }
        public static class Cloner
        {
            public static T Clone<T>(T source)
            {
                if (ReferenceEquals(source, null))
                    return default(T);
                var settings = new JsonSerializerSettings { ContractResolver = new ContractResolver() };
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source, settings), settings);
            }
            class ContractResolver : DefaultContractResolver
            {
                protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
                {
                    var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                        .Select(p => base.CreateProperty(p, memberSerialization))
                        .Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                            .Select(f => base.CreateProperty(f, memberSerialization)))
                        .ToList();
                    props.ForEach(p => { p.Writable = true; p.Readable = true; });
                    return props;
                }
            }
        }
    }
