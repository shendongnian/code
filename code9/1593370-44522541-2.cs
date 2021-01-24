    private void Serialize()
            {
                try
                {
                    // to Save columnorders to the file
                    var serializer = new XmlSerializer(typeof(A));
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
    
                    using (TextWriter writer = new StreamWriter(@"D:\Test_Jun13.xml"))
                    {
                        serializer.Serialize(writer, a, ns);
                    }
                }
                catch { }
            }
