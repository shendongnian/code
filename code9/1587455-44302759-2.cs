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
        // here convert _inicio and _fim to DateTime
        // And call the first constructor method with new parameters
        Medico(nome, especialidade, _NIF, inicioDateTime, fimDateTime);
    }
   
