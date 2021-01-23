        private static System.Collections.Generic.List<System.Reflection.FieldInfo> _fields;
        static Commands()
        {
            _fields = new System.Collections.Generic.List<System.Reflection.FieldInfo>();
            var fields = typeof(Commands).GetFields();
            var commandType = typeof(ICommand);
            foreach (var field in fields)
            {
                if (field.FieldType == commandType)
                {
                    _fields.Add(field);
                }
            }
        }
        public Commands()
        {
            foreach (var field in _fields)
            {
                field.SetValue(this, new ReckonCommand() as ICommand);
            }
        }
