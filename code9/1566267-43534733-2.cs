    using System;
    using System.IO;
    using System.Text;
    
    namespace ConsoleApp5
    {
        public class ConsoleTruncator : TextWriter
        {
            TextWriter m_console;
    
            int m_maxlinelength;
            int m_columnposition;
    
            public ConsoleTruncator(int maxlinelength)
            {
                m_maxlinelength = maxlinelength;
    
                m_console = Console.Out; // save console stream reference between we replace it
    
                Console.SetOut(this); // redirect console to this TextWriter
                // (don't do the `SetOut` here ... you need to separate out the
                // the attach and detach of the custom `TextWriter` to the
                // console into some other utility class/helper...for good structure)
            }
    
            public override Encoding Encoding
            {
                get
                {
                    return Encoding.UTF8;
                }
            }
    
            public override void Write(char value)
            {
                if (value == '\r')
                    return;
    
                if (value == '\n')
                {
                    OutputChar(value);
    
                    m_columnposition = 0;
                }
                else
                {
                    bool bRoom = (m_maxlinelength - m_columnposition) > 0;
    
                    if (bRoom)
                    {
                        OutputChar(value);
    
                        m_columnposition++;
                    }
                }
    
            }
    
            private void OutputChar(char value)
            { 
                m_console.Write(value);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                string[] somelines =
                {
                    "AAALorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam auctor neque quis euismod auctor. Fusce massa nibh, fringilla eu mi ornare, ullamcorper tristique nibh. Aenean eget neque111",
                    "BBBxxxxxxxx vvvvvvvvvvvvvvvvvvv xxxxxxxxxxxxxxxxx222",
                    "CCCNullam porta eu magna eget rutrum. Aenean orci urna, pretium ut odio vitae, euismod rhoncus ligula. Vivamus condimentum semper lacus id tempor. Phasellus at turpis a quam ornare tincidunt. Vivamus eleifend quam eget velit porttitor, sit amet laoreet risus consectetur. Mauris eu arcu sit amet ipsum vulputate porttitor. Phasellus elementum erat eu blandit semper. Integer eu metus urna. Pellentesque at posuere purus. Nu333",
                    "0123456789 0123456789 0123456789 0123456789 0123456789 0123456789\r\n0123456789+*+*+*+*+*0123456789+*+*+*+*+*0123456789",
                    "abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz\r\n\r\nABCDEFGHIJKLMNOPQRSTUVWXYZ ABCDEFGHIJKLMNOPQRSTUVWXYZ ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                };
    
                using (var consoleTruncator = new ConsoleTruncator(40))
                {
                    foreach(string s in somelines)
                    {
                        Console.WriteLine(s);
                    }
    
                    Console.WriteLine();
                    Console.Write("write a bit");
                    Console.Write("-write a bit more");
                    Console.Write("-write too muchhhhhhhhhhhhhhhh");
                }
    
                Console.ReadKey();
            }
        }
    }
