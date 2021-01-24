    var fees = from ...
               select new ChargeElementsNullable {
                    Prop1 = (some value),
                    Prop2 = (other value)
                }
    var ratestest = from ...
               select new ChargeElementsNullable {
                    Prop1 = (some value),
                    Prop2 = (other value)
                }
    var bothtogether = fees.Concat(ratestest);
