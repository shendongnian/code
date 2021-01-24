    public abstract class AbstractSerializer
    {
      public abstract void Serialize(string[][] model, string path);
    }
  
    public class XmlSerializer : AbstractSerializer
    {
      public override void Serialize(string[][] model, string path)
      {
        // your stuff
      }
    }
  
    public class CsvSerializer : AbstractSerializer
    {
      public string LineSeparator { get; set; } = "\r\n";
      public string ValueSeparator { get; set; } = ";";
  
      public override void Serialize(string[][] model, string path)
      {
        var stb = new System.Text.StringBuilder();
        for (int i = 0; i < model.Length; i++)
        {
          for (int j = 0; j < model[i].Length; j++)
          {
            // Example output:
            // 0;0;Chris
            // 0;1;call
            // 0;2;Anna
            // 1;0;Somebody
            // 1;1;call
            // 1;2;Wolf
            stb.Append(string.Join(ValueSeparator, i, j, model[i][j], LineSeparator));
          }
        }
      }
    }
