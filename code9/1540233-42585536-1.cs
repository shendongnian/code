        public static Func<object, Task<object>> BuildTaskWrapperFunction(Type returnType)
        {
            // manage Task<T> types
            Type taskResultType;
            if (IsATaskOfT(returnType, out taskResultType))
            {
                var f = MakeTaskWrappingMethodInfo.MakeGenericMethod(returnType);
                return (Func<object, Task<object>>)f.Invoke(null, new object[0]);
            } 
            // Manage Task
            if (typeof(Task).IsAssignableFrom(returnType)) return WrapBaseTask;
            
            // everything else: just wrap the synchronous result.
            return obj => Task.FromResult(obj);
        }
        // A Task is waited and then null is returned.
        // questionable, but it's ok for my scenario.
        private static async Task<object> WrapBaseTask(object obj)
        {
            var task = (Task) obj;
            if (task == null) throw new InvalidOperationException("The returned Task instance cannot be null.");
            await task;
            return null;
        }
        /// <summary> This method just returns a func that awaits for the typed task to complete
        /// and returns the result as a boxed object. </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Func<object, Task<object>> WrapTypedTask<T>()
        {
            return async obj => await (Task<T>)obj;
        }
        private static readonly Type TypeOfTask = typeof(Task<>);
        /// <summary> Returns true if the provided type is a Task&lt;T&gt; or
        /// extends it. </summary>
        /// <param name="type"></param>
        /// <param name="taskResultType">The type of the result of the Task.</param>
        /// <returns></returns>
        public static bool IsATaskOfT(Type type, out Type taskResultType)
        {
            while (type != null)
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == TypeOfTask)
                {
                    taskResultType = type.GetGenericArguments()[0];
                    return true;
                }
                type = type.BaseType;
            }
            taskResultType = null;
            return false;
        }
