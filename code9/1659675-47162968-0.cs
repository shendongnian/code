    public string CheckString(string s){
        if(s == "A")
            return "EntityA";//entity name from the database
        else if(s == "B")
            return "EntityB";//entity name from the database
    }
    
    public void main(){
        string entityName = CheckString("A");
        session.CreateCriteria(entityName).List<T>();
    }
