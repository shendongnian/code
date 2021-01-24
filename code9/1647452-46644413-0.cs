        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == delimiter)
            {
                parts.Add(buff.ToString());
                buff.Clear();
            }
            else
            {
                buff.Append(input[i]);
            }
        }
        // This you need to add
        if (!string.IsNullOrEmpty(buff.ToString()))
        {
            parts.Add(buff.ToString());
        }
        return parts.ToArray();
