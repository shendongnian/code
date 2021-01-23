    [DelimitedRecord("|")]
    [ConditionalRecord(RecordCondition.IncludeIfMatchRegex, "^CDI")]
    public class Cdi
    {
        public string Type { get; set; }
        public int Number { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Data3 { get; set; }
    }
    [DelimitedRecord("|")]
    [ConditionalRecord(RecordCondition.IncludeIfMatchRegex, "^CEX001")]
    public class Cex001
    {
        public string Type { get; set; }
        public int Number { get; set; }
        public string Data1 { get; set; }
    }
    [DelimitedRecord("|")]
    [ConditionalRecord(RecordCondition.IncludeIfMatchRegex, "^CCC")]
    public class Ccc
    {
        public string Type { get; set; }
        public int Number { get; set; }
    }
	
	
	            var input =
                @"CDI|11111|Data1|Data2|Data3
	CEX001|123131|Data1
	CCC|123131";
    var CdiEngine = new FileHelperEngine<Cdi>();
    var cdis = CdiEngine.ReadString(input);
    var cexEngine = new FileHelperEngine<Cex001>();
    var cexs = cexEngine.ReadString(input);
    var cccEngine = new FileHelperEngine<Ccc>();
    var cccs = cccEngine.ReadString(input);
