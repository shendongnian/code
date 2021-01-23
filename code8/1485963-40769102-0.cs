    var test = new Test
            {
                Date = nullDate.GetValueOrDefault(new DateTime()),
                Name = "String",
                AnotherDate = notNullDate.Value
            };
