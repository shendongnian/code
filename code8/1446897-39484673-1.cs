    public List<TDTO> GetAll()
    {
        var list = _repository.GetAll().ToList();
        return (List<TDTO>)_mapper.Map(list, list.GetType(), typeof(IList<TDTO>));
    }
