    public class CallTest {
    public void TestCode() {
        var items = new List<CallKeyValue>
        {
            new CallKeyValue {CallKey = CallKey.CallDate, Value1 = "11.04.2017"},
            new CallKeyValue {CallKey = CallKey.CallTime, Value1 = "15:43"},
            new CallKeyValue {CallKey = CallKey.FromPhoneNumber, Value1 = "5311234567"},
            new CallKeyValue {CallKey = CallKey.ToPhoneNumber, Value1 = "5311234587 "},
            new CallKeyValue {CallKey = CallKey.Duration, Value1 = "13*min"},
            new CallKeyValue {CallKey = CallKey.FromOperatorCode, Value1 = "TR",Value2 = "001"},
            new CallKeyValue {CallKey = CallKey.ToOperatorCode, Value1 = "TR",Value2 = "002"},
        };
        var st = new Stopwatch();
        //Test 1: ElapsedMilliseconds: 50, ElapsedTicks: 122023
        st.Start();
        IDictionary<string,dynamic> expando = new ExpandoObject();
        foreach(var item in items) {
            expando.Add(item.CallKey.ToString(),null);
            expando[item.CallKey.ToString()] = new { Value1 = item.Value1,Value2 = item.Value2 };
        }
        var cd = new CallDetail {
            CallDate = DateTime.Parse(expando[CallKey.CallDate.ToString()].Value1 + " " + expando[CallKey.CallTime.ToString()].Value1),
            FromPhoneNumber = expando[CallKey.FromPhoneNumber.ToString()].Value1,
            ToPhoneNumber = expando[CallKey.ToPhoneNumber.ToString()].Value1,
            Duration = Convert.ToInt32(expando[CallKey.Duration.ToString()].Value1.ToString().Split('*')[0]),
            DurationUnit = GetEnumKeyOfUnit(expando[CallKey.Duration.ToString()].Value1.ToString().Split('*')[1]),
            FromOperatorCountry = expando[CallKey.FromOperatorCode.ToString()].Value1,
            FromOperatorId = expando[CallKey.FromOperatorCode.ToString()].Value2,
            ToOperatorCountry = expando[CallKey.ToOperatorCode.ToString()].Value1,
            ToOperatorId = expando[CallKey.ToOperatorCode.ToString()].Value2
        };
        st.Stop();
        Console.WriteLine(st.ElapsedMilliseconds);
        Console.WriteLine(st.ElapsedTicks);
        st.Reset();
        //Test 2: ElapsedMilliseconds: 0, ElapsedTicks: 328
        st.Start();
        var cd3 = items.Select(s => {
            IDictionary<string,dynamic> expando2 = new ExpandoObject();
            expando2.Add(s.CallKey.ToString(),null);
            expando2[s.CallKey.ToString()] = new { Value1 = s.Value1,Value2 = s.Value2 };
            var item = new CallDetail {
                CallDate = DateTime.Parse(expando2[CallKey.CallDate.ToString()].Value1 + " " + expando2[CallKey.CallTime.ToString()].Value1),
                FromPhoneNumber = expando2[CallKey.FromPhoneNumber.ToString()].Value1,
                ToPhoneNumber = expando2[CallKey.ToPhoneNumber.ToString()].Value1,
                Duration = Convert.ToInt32(expando2[CallKey.Duration.ToString()].Value1.ToString().Split('*')[0]),
                DurationUnit = GetEnumKeyOfUnit(expando2[CallKey.Duration.ToString()].Value1.ToString().Split('*')[1]),
                FromOperatorCountry = expando2[CallKey.FromOperatorCode.ToString()].Value1,
                FromOperatorId = expando2[CallKey.FromOperatorCode.ToString()].Value2,
                ToOperatorCountry = expando2[CallKey.ToOperatorCode.ToString()].Value1,
                ToOperatorId = expando2[CallKey.ToOperatorCode.ToString()].Value2
            };
            return item;
        });
        st.Stop();
        Console.WriteLine(st.ElapsedMilliseconds);
        Console.WriteLine(st.ElapsedTicks);
        st.Reset();
        //Test 3: ElapsedMilliseconds: 0, ElapsedTicks: 1390
        st.Start();
        var cd2 = new CallDetail {
            CallDate = DateTime.Parse(items.FirstOrDefault(f => f.CallKey == CallKey.CallDate)?.Value1 + " " + items.FirstOrDefault(f => f.CallKey == CallKey.CallTime)?.Value1),
            FromPhoneNumber = items.FirstOrDefault(f => f.CallKey == CallKey.FromPhoneNumber)?.Value1,
            ToPhoneNumber = items.FirstOrDefault(f => f.CallKey == CallKey.ToPhoneNumber)?.Value1,
            Duration = Convert.ToInt32(items.FirstOrDefault(f => f.CallKey == CallKey.Duration)?.Value1.Split('*')[0]),
            DurationUnit = GetEnumKeyOfUnit(items.FirstOrDefault(f => f.CallKey == CallKey.Duration)?.Value1.Split('*')[1]),
            FromOperatorCountry = items.FirstOrDefault(f => f.CallKey == CallKey.FromOperatorCode)?.Value1,
            FromOperatorId = items.FirstOrDefault(f => f.CallKey == CallKey.FromOperatorCode)?.Value2,
            ToOperatorCountry = items.FirstOrDefault(f => f.CallKey == CallKey.ToOperatorCode)?.Value1,
            ToOperatorId = items.FirstOrDefault(f => f.CallKey == CallKey.ToOperatorCode)?.Value2
        };
        st.Stop();
        Console.WriteLine(st.ElapsedMilliseconds);
        Console.WriteLine(st.ElapsedTicks);
    }
    private DurationUnit? GetEnumKeyOfUnit(string unit) {
        switch(unit) {
            case "min":
                return DurationUnit.Minute;
            case "hour":
                return DurationUnit.Hour;
        }
        return null;
    }
    }
