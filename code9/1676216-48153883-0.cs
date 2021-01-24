        public class IRCUBE
        {
            public string CurveDefinitionId { get; set; }
            public string CurveFamilyId { get; set; }
            public string CurveName { get; set; }
            public string MarketDataSet { get; set; }
            public string Referenced { get; set; }
        
            public override string ToString()
            {
                StringBuilder msg = new StringBuilder();
        
                msg.AppendLine("CurveDefinitionId: " + CurveDefinitionId);
                msg.AppendLine("CurveFamilyId: " + CurveFamilyId);
                msg.AppendLine("CurveName: " + CurveName);
                msg.AppendLine("MarketDataSet: " + MarketDataSet);
                msg.AppendLine("Referenced: " + Referenced);
        
                return msg.ToString();
            }
        }
    
        using (var p = new ChoJSONReader("sample14.json")
            .WithField("USD", jsonPath: "$..USD.FCC-IRCUBE", fieldType: typeof(IRCUBE[]))
            .WithField("EUR", jsonPath: "$..EUR.FCC-IRCUBE", fieldType: typeof(IRCUBE[]))
            .WithField("GBP", jsonPath: "$..GBP.FCC-IRCUBE", fieldType: typeof(IRCUBE[]))
        )
        {
            foreach (dynamic rec in p)
            {
                Console.WriteLine("USD:");
                Console.WriteLine();
                foreach (var curr in rec.USD)
                {
                    Console.WriteLine(curr.ToString());
                }
                Console.WriteLine();
            }
        }
