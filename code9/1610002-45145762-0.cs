    public class retornoRespostas
    {
        public string Status { get; set; }
        public string Descricao { get; set; }
        public List<RespostaWrapper> Respostas { get; set; }
    }
    
    public class RespostaWrapper
    {
        public Resposta Resposta { get; set; }
    }
    
    public class Resposta
    {
        public string Campanha { get; set; }
        public string Telefone { get; set; }
        public string Data { get; set; }
        public string mensagem { get; set; }
    }
