    private static GenericRecord ConvertGenericRecord(GenericRecord x) {
        float c1, c2, c3;
        float.TryParse(x.Col1, out c1);
        float.TryParse(x.Col2, out c2);
        float.TryParse(x.Col3, out c3);
        return new GenericRecord {
            ConvertedCol1 = c1;
            ConvertedCol2 = c2;
            ConvertedCol3 = c3;
            GroupName = x.GroupName
        };
    }
