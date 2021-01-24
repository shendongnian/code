    Vector3 ConvertFromString(string input)
    {
        if (input != null)
        {
            var vals = input.Split(',').Select(s => s.Trim()).ToArray()
            if (vals.Length == 3)
            {
                Single v1, v2, v3;
                if (Single.TryParse(vals[0], out v1) &&
                    Single.TryParse(vals[1], out v2) &&
                    Single.TryParse(vals[2], out v3))
                    return new Vector3(v1, v2, v3);
                else
                    throw new ArgumentException();
            }
            else
                throw new ArgumentException();
        }
        else
            throw new ArgumentException();
    }
