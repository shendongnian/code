            CsvReader csv = new CsvReader(new StreamReader(file.OpenReadStream()));
            csv.Configuration.RegisterClassMap<PessoaCSVMap>();
            csv.Configuration.Delimiter = ";";
            csv.Configuration.HeaderValidated = null;
            csv.Configuration.MissingFieldFound = null;
            List<Pessoas> pessoas = csv.GetRecords<Pessoas>().ToList();
----------
    public sealed class PessoaCSVMap : ClassMap<Pessoas>
    {
        public PessoaCSVMap()
        {
            Map(m => m.Nome).Name("Nome", "Name");
            ... etc
        }
    }
