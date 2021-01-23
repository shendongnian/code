    public class Cliente {
    
            public virtual long id                          { set; get; }
            public virtual long codigo                      { set; get; }
            public virtual String nome                      { set; get; }
            public virtual String sexo                      { set; get; }
            public virtual String cpf                       { set; get; }
            public virtual String rg                        { set; get; }
            public virtual DateTime dtNascimento            { set; get; }
            public virtual Endereco endereco                { set; get; } //Embeddable
    
            public Cliente() { }
        }
    
    
    
    public class Endereco {
    
            public  String endereco;
            public  String numero;
            public  String bairro;
            public  String complemento;
            public  String cidade;
            public  String cep;
            public  EstadosBrasil uf;
    
            public Endereco() {            
            }
        }
