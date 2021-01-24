    using System;
    using System.IO;
    using System.Runtime.Serialization;
    
    namespace ConsoleApp1
    {
        [DataContract]
        public class TestDto
        {
            [DataMember(IsRequired = false, EmitDefaultValue = false, Name = "p0", Order = 0)]
            public string Name { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var input = new TestDto { Name = " with leading whitespace" };
    
                byte[] data;
                {
                    var seralizer = new DataContractSerializer(typeof(TestDto));
                    using (var mem = new MemoryStream())
                    {
                        seralizer.WriteObject(mem, input);
                        data = mem.ToArray();
                    }
                }
                {
                    var seralizer = new DataContractSerializer(typeof(TestDto));
                    using (var mem = new MemoryStream(data))
                    {
                        var output = (TestDto)seralizer.ReadObject(mem);
                        Console.WriteLine(">{0}<", output.Name);
                    }
                }
            }
        }
    }
