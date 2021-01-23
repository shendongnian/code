    List<bool> YourFunction(YourDebuggerThing Input)
    {
        List<bool> Result = new List<bool>();
        if (Input.Condition1 == false || Input.Condition2 == false || Input.Condition3 == false || Input.Condition4 == false || Input.Condition5 == false)
            Result.Add(false); // first element is always the overall status
        if(Input.Condition1 == false) Result.Add(false); else Result.Add(true); // element 2 is condition 1
        if(Input.Condition2 == false) Result.Add(false); else Result.Add(true); // element 3 is condition 2
        // ..
        // ConditionN
        return Result;
    }
