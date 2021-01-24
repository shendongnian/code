    static void Main()
        {
            string _orderxml = @"<Days>    <Day Name=""Wednesday"">        <Task Order=""1"">TestTask</Task>        <Task Order=""2"">Test2</Task>    </Day></Days>";
            string today = DateTime.Now.ToString("dddd");
            var allItems = new Dictionary<string, int>();
            XElement root = XElement.Parse(_orderxml);
            IEnumerable<XElement> address =
                from el in root.Elements("Day")
                where el.Attribute("Name").Value == today
                select el;
            foreach (XElement e in address)
            {
                foreach (XElement t in e.Descendants())
                {
                    string task = t.Value.ToString();
                    int order = int.Parse(t.Attribute("Order").Value.ToString());
                    allItems.Add(task, (int)order);
                }
            }
        }
