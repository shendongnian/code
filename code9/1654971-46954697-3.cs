    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using System.Xaml;
    public class Foo
    {
        public PointCollection Points { get; set; }
    }
    var foo = new Foo
    {
        Points = new PointCollection()
        {
            new Point { X = 1, Y = 2 },
            new Point { X = 3, Y = 4 }
        }
    };
    using (var fs = new FileStream("test.xml", FileMode.Create))
        XamlServices.Save(fs, foo);
    using (var fs = new FileStream("test.xml", FileMode.Open))
        foo = (Foo)XamlServices.Load(fs);
