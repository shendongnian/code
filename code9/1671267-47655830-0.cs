    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reactive.Linq;
    using System.Windows.Forms;
    namespace Anything
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var random = new Random();
                var bounds = Screen.PrimaryScreen.Bounds;
                var extents = new Dictionary<int, Rectangle>();
                for (var i = 0; i < 300; i++)
                {
                    var x = random.Next(bounds.Width);
                    var y = random.Next(bounds.Height);
                    var w = random.Next(bounds.Width - x);
                    var h = random.Next(bounds.Height - y);
                    extents[i] = new Rectangle(x, y, w, h);
                }
                var domains = from time in Observable.Interval(TimeSpan.FromMilliseconds(100))
                              from extent in extents
                              where extent.Value.Contains(Control.MousePosition)
                              select extent.Key;
                var subscription = domains.Subscribe(id => Console.Write($"{id},"));
                Console.ReadKey();
                subscription.Dispose();
            }
        }
    }
