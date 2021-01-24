    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace Anything
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var dict = new Dictionary<TextBox, int>
                {
                    [new TextBox {Top = 25}] = 250,
                    [new TextBox {Top = 50}] = 500,
                    [new TextBox {Top = 75}] = 750,
                    [new TextBox {Top = 100}] = 2000
                };
                var form = new Form();
                var button = new Button {Text = "Click Me"};
                button.Click += (o, e) =>
                {
                    foreach (var item in dict)
                    {
                        Task
                            .Delay(TimeSpan.FromMilliseconds(item.Value))
                            .ContinueWith(_ => item.Key.BackColor = Color.Red);
                    }
                };
                form.Controls.Add(button);
                form.Controls.AddRange(dict.Keys.OfType<Control>().ToArray());
                form.ShowDialog();
                Console.ReadKey();
            }
        }
    }
