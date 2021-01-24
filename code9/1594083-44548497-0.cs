    class Test {
        public decimal? Qte { get; set; }
    }
...
    int columnIndex = reader.GetOrdinal("DL_Qte");
    decimal? qte = null;
    if(!reader.IsDBNull(columnIndex))
        qte = reader.GetDecimal(columnIndex);  // <----- !!!
    Test t = new Test { Qte = qte };
