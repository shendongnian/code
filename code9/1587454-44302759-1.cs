    public Medico(string nome, string especialidade, int _NIF, DateTime _inicio, DateTime _fim)
    {
        Nome = nome;
        Especialidade = especialidade;
        NIF = _NIF;
        Inicio = _inicio;
        Fim = _fim;
    }
    public Medico(string nome, string especialidade, int _NIF, string _inicio, string _fim)
    {
        // here you can call other constructor (first one) after requiered conversion of _inicio and _fim to DateTime is done
    }
    
