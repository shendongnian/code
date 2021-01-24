    public T HandlingT(T obj){
        if(condition && obj == null){
            obj = new T();
        }
        return obj;
    }
