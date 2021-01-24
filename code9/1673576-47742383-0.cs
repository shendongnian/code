    using System.Linq;
    using System.Xml.Linq;
    namespace ConsoleApp
    {
        class Program
        {
            static void Main (string[] args)
            {
                var xml = @"<SubTexture name=""explosion0000.png"" x=""180"" y=""474"" width=""24"" height=""25""/>
                            <SubTexture name=""explosion0001.png"" x=""422"" y=""609"" width=""30"" height=""30""/>
                            <SubTexture name=""explosion0002.png"" x=""395"" y=""981"" width=""34"" height=""34""/>
                            <SubTexture name=""explosion0003.png"" x=""354"" y=""981"" width=""39"" height=""39""/>";
                var xElement = XElement.Parse ("<rootHack>" + xml + "</rootHack>"); // XElement requires root element, so we need to use a hack
                var list = xElement.Elements ().Select (element => new MyClass
                {
                    Name   = element.Attribute ("name").Value,
                    X      = int.Parse (element.Attribute ("x").Value),
                    Y      = int.Parse (element.Attribute ("y").Value),
                    Width  = int.Parse (element.Attribute ("width").Value),
                    Height = int.Parse (element.Attribute ("height").Value),
                }).ToList ();
            }
        }
        class MyClass
        {
            public string Name;
            public int X, Y, Width, Height;
            public override string ToString () => $"{Name}, X={X} Y={Y}, W={Width} H={Height}";
        }
    }
