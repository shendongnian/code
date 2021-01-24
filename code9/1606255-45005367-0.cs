    foreach (var trans in xDocument.Descendants("Transaction"))
    {
        XElement setElement = trans.Descendants("Set").FirstOrDefault();
        if (setElement != null)
        {
            var val1 = (string)setElement.Element("szCustomerID");
            var val2 = (string)setElement.Element("szCustomerName");
            var val3 = (string)setElement.Element("szExternalID");
            if (val1 != null && val3 != null && val3 != null)
            {
                dataToBeWritten.Append(val1);
                dataToBeWritten.Append(",");
                dataToBeWritten.Append(val2);
                dataToBeWritten.Append(",");
                dataToBeWritten.Append(val3);
                dataToBeWritten.Append(",");
                dataToBeWritten.Append(Environment.NewLine);
            }
        }
    }
