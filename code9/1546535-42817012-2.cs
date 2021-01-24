    public class ICD {
    
       public int Id { get; set; }
       public string Name { get; set; }
       public short[5] Rates { get; set; }
       public int[5] Grades { get; set; }
    
       public byte[] Serialize() {
          using (MemoryStream m = new MemoryStream()) {
             using (BinaryWriter writer = new BinaryWriter(m)) {
                writer.Write(Id);
                writer.Write(Name);
             }
             return m.ToArray();
          }
       }
    
       public static ICD Desserialize(byte[] data) {
          ICD result = new ICD();
          using (MemoryStream m = new MemoryStream(data)) {
             using (BinaryReader reader = new BinaryReader(m)) {
                result.Id = reader.ReadInt32();
                result.Name = reader.ReadString();
             }
          }
          return result;
       }
    
    }
