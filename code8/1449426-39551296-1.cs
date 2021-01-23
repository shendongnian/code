            var csv = @"London,Dubai,4
    Dubai,Mumbai,8
    Dubai,Dhaka,4";
            string json;
            using (var stream = new StringReader(csv))
            using (TextFieldParser parser = new TextFieldParser(stream))
            {
                parser.SetDelimiters(new string[] { "," });
                var query = parser.ReadAllFields()
                    .Select(a => new { From = a[0], To = a[1], Duration = int.Parse(a[2]) });
                json = new JavaScriptSerializer().Serialize(query);
            }
