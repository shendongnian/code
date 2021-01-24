    public void DoSomething(Result result)
    {
        if(result != null){
            if(result.Actions != null){
                return result.Actions.Utterance;
            }
        }
        return null;
    }
