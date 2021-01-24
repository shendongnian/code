    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication57
    {
        class Program
        {
            const string file = "";
            static void Main(string[] args)
            {
                FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(fs);
                string inputline = "";
                State state = State.FIND_HEADER;
                while((inputline = reader.ReadLine()) != null)
                {
                    switch (state)
                    {
                        case State.FIND_HEADER:
                            if (inputline.StartsWith("#header"))
                            {
                                state = State.READ_TABLE;
                            }
                            break;
                        case State.READ_TABLE:
                            Table t = Table.Load(fs);
                            break;
                    }
                }
            }
            enum State
            {
                FIND_HEADER,
                READ_TABLE
            }
        }
    }
