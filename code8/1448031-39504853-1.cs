     string searchid = "1";
            string[] values = File.ReadAllText(@"Complete Path Of File").Split(new char[] { '\n' });
            StringBuilder ObjStringBuilder = new StringBuilder();
            for (int i = 0; i < values.Length - 1; i++)
            {
                if (values[i].StartsWith(searchid) == false)
                {
                    ObjStringBuilder.Append(values[i]);
                    ObjStringBuilder.AppendLine();
                }
            }
            File.WriteAllText(@"Complete Path Of File", ObjStringBuilder.ToString());
        }
