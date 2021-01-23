    XElement doc = XElement.Load("Test.xml");
            IEnumerable<XElement> yearList =
                                     from el in doc.Elements("YEAR")
                                    select el;
            List<YearStat> yearData = new List<YearStat>();
            foreach (XElement yearEle in yearList)
            {
                YearStat year = new YearStat();
                year.Year = int.Parse((string)yearEle.Attribute("NUMBER"));
                var monthList = yearEle.Elements("Month");
                List<int> monthData = new List<int>();
                foreach(XElement monthEle in monthList)
                {
                    monthData.Add(int.Parse((string)monthEle.Attribute("NUMBER")));
                }
                year.Months = monthData;
                yearData.Add(year);
            }
