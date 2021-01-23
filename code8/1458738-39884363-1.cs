    [Serializable]
        public class Conta {
    
            public virtual long id                      { set; get; }        
            public virtual Cliente cliente              { set; get; }
            public virtual String historico             { set; get; }
            public virtual DateTime dtLancamento        { set; get; }
            public virtual DateTime dtVencimento        { set; get; }
            public virtual decimal valorPagar           { set; get; } //total vendas
            public virtual decimal valorAcrescimo       { set; get; } //total acrescimo
            public virtual decimal valorFinal           { set; get; } //total pagar
            public virtual DateTime dtPagamento         { set; get; }
            public virtual int tipoConta                { set; get; }  //1 receber, 2 pagar
            public virtual PlanoDeConta planoConta      { set; get; }
            public virtual int status                   { set; get; } //0 ativa, 1 fechada, 2 cancelada, 3 aguardando pagamento
            public virtual Venda venda                  { set; get; }
    
    
            public Conta() {
            }
    
            public Conta(Cliente cliente, String historico, DateTime dtLancamento, DateTime dtVencimento, 
                        decimal valorPagar, decimal valorAcrescimo, decimal valorFinal, int status){
    
                            this.cliente = cliente;
                            this.historico = historico;
                            this.dtLancamento = dtLancamento;
                            this.dtVencimento = dtVencimento;
                            this.valorPagar = valorPagar;
                            this.valorAcrescimo = valorAcrescimo;
                            this.valorFinal = valorFinal;
                            this.status = status;
            }
    
        }
