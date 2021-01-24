    public sealed class PessoaCSVMap : ClassMap<Pessoas>
    {
        public PessoaCSVMap()
        {
            Map(m => m.NomeCompleto).Name("Nome", "Name");
            Map(m => m.Documento).Name("Documento", "Doc", "CPF");
            Map(m => m.Email1).Name("Email", "Email1", "E-mail", "E-mail1");
            Map(m => m.PessoaId).Ignore();
        }
    }
