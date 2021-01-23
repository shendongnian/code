    var taskType = executing.GetType();
    bool isTaskOfT =
        taskType.IsGenericType
        && taskType.GetGenericTypeDefinition() == typeof(Task<>);
    if (isTaskOfT)
    {
        object result = taskType.GetProperty("Result").GetValue(executing);
    }
