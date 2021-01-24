    namespace Tasks
    {
        public class Remember : Task
        {
            public Remember()
            {
                name = typeof(Remember).Name;
                priority = Task.Priority.High;
            }
        }
    }
