        public class Atendimento
        {
            public int Id { get; set; }
            public string Field1 { get; set; }
            public virtual CaixaTransacao CaixaTransacao { get; set; }
        }
        public class CaixaTransacao
        {
            public int Id { get; set; }
            public string Field2 { get; set; }
            public string Field3 { get; set; }
            // public int AtendimentoID { get; set; } // DELETE THIS ROW. See OnModelCreating
            public virtual Atendimento Atendimento { get; set; }
        }
