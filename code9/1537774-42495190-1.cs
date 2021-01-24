    class Program
    {
        static void Main(string[] args)
        {
            var hw = new Hardware()
            {
                cpu_name = "ABC Pentium xyz",
                ram_size = 123,
                hd = new List<HardDisk>()
                {
                    new HardDisk() {
                        model = "Toshiba XYZ",
                        size = 123
                    },
                    new HardDisk() {
                        model = "Logitech XYZ",
                        size = 99
                    }
                }
            };
            var xml = new System.Xml.Serialization.XmlSerializer(typeof(Hardware));
            var ns = new System.Xml.Serialization.XmlSerializerNamespaces();
            ns.Add("", "");
            xml.Serialize(Console.Out, hw, ns);
        }
    }
