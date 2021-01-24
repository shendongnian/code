    numbers.Trim().Split(',')
        .Select(text => {
            int result;
            bool isNumeric = Int32.TryParse(text, out result);
            return new { result, isNumeric };
        })
        .Where(entry => entry.isNumeric)
        .Select(entry => entry.result)
        .ToArray()
