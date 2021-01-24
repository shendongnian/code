    /// <summary> 
    /// Casts a <see cref="Task"/> to a <see cref="Task{TResult}"/>. 
    /// This method will throw an <see cref="InvalidCastException"/> if the specified task 
    /// returns a value which is not identity-convertible to <typeparamref name="T"/>. 
    /// </summary>
    public static async Task<T> Cast<T>(this Task task)
    {
        if (task == null)
            throw new ArgumentNullException(nameof(task));
        if (!task.GetType().IsGenericType || task.GetType().GetGenericTypeDefinition() != typeof(Task<>))
            throw new ArgumentException("An argument of type 'System.Threading.Tasks.Task`1' was expected");
    
        await task.ConfigureAwait(false);
    
        object result = task.GetType().GetProperty(nameof(Task<object>.Result)).GetValue(task);
        return (T)result;
    }
