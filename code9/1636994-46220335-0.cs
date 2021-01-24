    public T HandlingT(T obj){
        if(condition && obj == null){
            obj = new T();
        }
        //...handling object T
    
       return obj;
    }
