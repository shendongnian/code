            string s = "Domain_FieldName";
            var x = s.Split(new[] { '_' }, StringSplitOptions.None);
            var xx = new
            {
               Value = "test",
               DataType = "string",
               Domain =x[0],
               Schema ="",
               TableName ="",
               FieldName = x[1]
            };
