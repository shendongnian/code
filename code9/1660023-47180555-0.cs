    using (var fs = new StreamWriter(pathAndFileName)) {
        while (reader.Read()) {
            var newContent = string.Format(
                "{0}\t{1}"
                , reader.GetValue(0).ToString().Trim()
                , reader.GetValue(1).ToString().Trim()
            );
            fs.WriteLine(newContent);
        }
    }
