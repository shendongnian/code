    for(int i = 1; i <= contacts.Count; i++)
    {
        obejct o = contacts[i];
        ContactItem contact = o as ContactItem;
        if (o != null)
        {
            ItemProperties properties = contact.ItemProperties;
            StringBuilder newLine = new StringBuilder();
            for (int j = 1; j <= properties.Count; j++)
            {
                ItemProperty property = properties[j];
                var value = "";
                if (property.Value == null)
                {
                    value = "null,";
                    Console.WriteLine(value);
                    newLine.Append(value);
                }
                else
                {
                    value =  property.Value.ToString() + ",";
                    newLine.Append(value);
                }
                Marshal.ReleaseComObject(property);
            }
            newLine.Append(Environment.NewLine);
            WriteToCSV(writer, newLine);
            Marshal.ReleaseComObject(properties);
            Marshal.ReleaseComObject(contact);
        }
        Marshal.ReleaseComObject(o);
    }
 
 
