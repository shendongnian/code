    class ValorInfo
    {
	    [JsonProperty("nome")]
	    public string Nome { get; set; }
	    [JsonProperty("valor")]
	    public double Valor { get; set; }
	    [JsonProperty("ultima_consulta")]
	    public int UltimaConsulta { get; set; }
    	[JsonProperty("fonte")]
	    public string Fonte { get; set; }
    }
