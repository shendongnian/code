    public IndexViewModel Index()
    {
        var vm = new IndexViewModel()
        {
            Items = _mapper.map<List<Item>>(_service.GetSomeData())
        };
        return vm;
    }
    public GetViewModel Get(int id)
    {
        var vm = _mapper.Map<GetViewModel>(_service.get(id));
        return vm;
    }
