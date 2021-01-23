    [Serializable]
    public class Conta {
    
            public virtual long id                      { set; get; }
            public virtual Cliente cliente              { set; get; }
            public virtual String historico             { set; get; }
            public virtual DateTime dtLancamento        { set; get; }
            public virtual DateTime dtVencimento        { set; get; }
            public virtual decimal valorFinal           { set; get; }
    
            public Conta() {
            }
        }
    
    [Serializable]
    public class Cliente {
            public virtual int id               { set; get; }
            public virtual string nome          { set; get; }
    
            public Cliente() {
            }
    
            public override string ToString() {
                return nome;
            }
    
        }
