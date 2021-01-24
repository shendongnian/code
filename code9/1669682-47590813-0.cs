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
        var settings = new XmlWriterSettings ();
        settings.OmitXmlDeclaration = true;
        settings.Indent = true;
        settings.NewLineOnAttributes = true;
        var sww = new System.IO.StringWriter ();
        XmlWriter writer = XmlWriter.Create (sww, settings);
        xs.Serialize (writer, m);
        Console.WriteLine (sww.ToString ().Replace ("><", ">\r\n<"));
      }
    }
