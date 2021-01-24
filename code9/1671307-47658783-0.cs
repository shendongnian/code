    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    namespace Anything
    {
        public class Program
        {
            public static void Main(string[] _)
            {
                var form = new Form();
                List<Button> buttonlist = new List<Button>();
                for (int i = 0; i < 5; i++)
                {
                    Button but = new Button();
                    but.Name = Convert.ToString(i);
                    but.Location = new Point(50 + i * 20, 50);
                    but.Size = new Size(20, 20);
                    buttonlist.Add(but);
                    but.MouseUp += (s, args) =>
                    {
                        if (args.Button == MouseButtons.Right)
                        {
                            // do your thing
                        }
                    };
                    form.Controls.Add(but);
                }
                form.ShowDialog();
                Console.ReadKey();
            }
        }
    }
