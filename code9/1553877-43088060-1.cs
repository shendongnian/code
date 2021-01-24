    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.IO;
    static class P
    {
        static void Main()
        {
            var random = new Random(12345);
            // start with 100
            var archive = CreateData(random, 100);
            Update(archive);
            Refresh(ref archive);
    
            // make it bigger
            archive = CreateData(random, 200);
            Update(archive);
            Refresh(ref archive);
    
            // make it smaller
            archive = CreateData(random, 50);
            Update(archive);
            Refresh(ref archive);
    
            // go wild
            for (int i = 0; i < 1000; i++)
            {
                archive = CreateData(random, random.Next(0, 500));
                Update(archive);
                Refresh(ref archive);
            }
    
        }
        static Archive CreateData(Random random, int dataCount)
        {
            var archive = new Archive();
            var data = archive.data;
            for (int i = 0; i < dataCount; i++)
            {
                data.Add(new ArchiveData
                {
                    period = random.Next(10000),
                    sourcefolder = CreateString(random, 50),
                    destinationfolder = CreateString(random, 50)
                });
            }
            return archive;
        }
    
        private static unsafe string CreateString(Random random, int maxLength)
        {
            const string Alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
            int len = random.Next(maxLength + 1);
            char* chars = stackalloc char[len];
            for (int i = 0; i < len; i++)
            {
                chars[i] = Alphabet[random.Next(Alphabet.Length)];
            }
            return new string(chars, 0, len);
        }
    
        static string probuffile = "my.bin";
        public static void Refresh(ref Archive arc)
        {
            if (File.Exists(probuffile))
            {
                using (var fs = File.OpenRead(probuffile))
                {
                    arc = Serializer.Deserialize<Archive>(fs);
                    Console.WriteLine("Read: {0} items, {1} bytes", arc.data.Count, fs.Length);
                }
            }
        }
    
        public static void Update(Archive arc)
        {
            using (var fs = File.Create(probuffile))
            {
                Serializer.Serialize<Archive>(fs, arc);
                fs.SetLength(fs.Position);
                Console.WriteLine("Wrote: {0} items, {1} bytes", arc.data.Count, fs.Length);
            }
        }
    }
    
    [Serializable, ProtoContract(Name = @"Archive"), ProtoInclude(1, typeof(List<ArchiveData>))]
    public partial class Archive : IExtensible
    {
        [ProtoMember(1, IsRequired = true, OverwriteList = true, Name = @"data", DataFormat = DataFormat.Default)]
        public List<ArchiveData> data { get; set; }
    
        public Archive()
        {
            data = new List<ArchiveData>();
        }
    
        private IExtension extensionObject;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref extensionObject, createIfMissing);
        }
    }
    [ProtoContract]
    public struct ArchiveData
    {
        [ProtoMember(1, IsRequired = false, OverwriteList = true, Name = @"sourcefolder", DataFormat = DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string sourcefolder { get; set; }
    
        [ProtoMember(2, IsRequired = false, OverwriteList = true, Name = @"destinationfolder", DataFormat = DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string destinationfolder { get; set; }
    
        [ProtoMember(3, IsRequired = false, OverwriteList = true, Name = @"period", DataFormat = DataFormat.FixedSize)]
        [global::System.ComponentModel.DefaultValue((int)0)]
        public int period { get; set; }
    
        public ArchiveData(string sfolder = "", string dfolder = "", int priod = 0)
        {
            sourcefolder = sfolder;
            destinationfolder = dfolder;
            period = priod;
        }
    }
