    if (reader["Version"] == actualVersion)
    {
        while (reader.ReadToFollowing("Input"))
        {
            string value = reader.ReadElementContentAsString();
            // or
            int value = reader.ReadElementContentAsInt();
        }
    }
