        class MyResultClass
        {
            public string Sname { get; set; }
            public string Settings { get; set; }
        }
        private MyResultClass Convert(string str)
        {
            var newStr = str.Replace("\"Settings\"", "VERYUNIQUEKEYWORD")
                .Replace("\"Sname\"", "ANOTHERKEYWORD")
                .Replace("\"", "QUOTE")
                .Replace("VERYUNIQUEKEYWORD", "\"Settings\"")
                .Replace("ANOTHERKEYWORD","\"Sname\"")
                .Replace(":QUOTE",":\"")
                .Replace("QUOTE,","\","); 
               
            var myObj = JsonConvert.DeserializeObject<MyResultClass>(newStr);
            myObj.Settings = myObj.Settings.Replace("QUOTE", "\"");
            return myObj;
        }
