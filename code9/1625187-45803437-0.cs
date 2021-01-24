    using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                Console.Write(mi.Invoke(o, null));
                string allConsoleOutput = stringWriter.ToString();
                MessageBox.Show(allConsoleOutput, "Output");
            }
