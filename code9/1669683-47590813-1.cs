    public class Location { public string L; }
    public class MyData { public Location[] Locations { get; set; } }
    internal class Program
    {
      static void Main ()
      {
        // testdata
        var m = new MyData { Locations = new Location[2] { new Location { L = "L1" }, new Location { L = "L2" } } };
        // simple Serializer
        var xs = new XmlSerializer (typeof (MyData));
        DoSerialize (m, xs);
        Console.WriteLine ();
        var xs2 = new XmlSerializer (typeof (MyData), new XmlAttributeOverrides (), new Type[] { }, new XmlRootAttribute { Namespace = "MyNewNamspace" }, "");
        DoSerialize (m, xs2);
        Console.ReadLine ();
      }
      static void DoSerialize (MyData m, XmlSerializer xs)
      {
        var settings = new XmlWriterSettings
        {
          OmitXmlDeclaration = true,
          Indent = true,
          NewLineOnAttributes = true
        };
        var sww = new System.IO.StringWriter ();
        var writer = XmlWriter.Create (sww, settings);
        xs.Serialize (writer, m);
        Console.WriteLine (sww.ToString ().Replace ("><", ">\r\n<"));
      }
    }
