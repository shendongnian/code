    class TestClass
    {
        internal static void Test()
        {
            // Verify the old and new algorithms generate identical XML
            foreach (var i in new[] { 0, 1, 2, 100 })
            {
                var old1 = TestStringWriteAndParse(i);
                var new1 = TestDirectWrite(i);
                if (old1.OuterXml != new1.OuterXml)
                {
                    throw new InvalidOperationException("old1.OuterXml != new1.OuterXml");
                }
            }
            // Find a number of records that generate an out-of-memory exception whcn converting to an intermediate StringBuilder and string:
            uint size = 20000;
            try
            {
                while (size < int.MaxValue / 2)
                {
                    TestStringWriteAndParse((int)size);
                    size = checked(size * 2);
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            GC.Collect();
            // Verify that number of records can be written directly using  XmlDocument.CreateNavigator.AppendChild()
            try
            {
                TestDirectWrite((int)size);
                Console.WriteLine("SUCCEEDED in writing {0} DataTable records to an XmlDocument", size);
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAILED in writing {0} DataTable records to an XmlDocument:", size);
                Console.WriteLine(ex);
                throw;
            }
        }
        static DataTable GetData(int count)
        {
            var table = new DataTable();
            table.TableName = "Test";
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Height", typeof(double));
            table.Columns.Add("NetWorth", typeof(decimal));
            for (int i = 0; i < count; i++)
            {
                DataRow row = table.NewRow();
                row["Name"] = "Bob Cratchit " + i.ToString();
                row["Height"] = 6.023;
                row["NetWorth"] = 101.01 + (10 * i);
                table.Rows.Add(row);
            }
            return table;
        }
        static XmlDocument TestDirectWrite(int count)
        {
            DataTable dt = GetData(count);// contains 20000 records.
            XmlDocument sd = new XmlDocument();
            using (XmlWriter writer = sd.CreateNavigator().AppendChild())
            {
                dt.WriteXml(writer);
            }
            return sd;
        }
        static XmlDocument TestStringWriteAndParse(int count)
        {
            DataTable dt = GetData(count);// contains 20000 records.
            StringWriter sw = new StringWriter();
            dt.WriteXml(sw);
            XmlDocument sd = new XmlDocument();
            sd.LoadXml(sw.ToString());
            return sd;
        }
    }
