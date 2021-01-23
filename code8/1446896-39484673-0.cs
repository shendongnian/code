    public IList<TDTO> GetAll()
    {
        var list = _repository.GetAll().ToList();
        return (IList<TDTO>)_mapper.Map(list, list.GetType(), typeof(IList<TDTO>));
    }
