        void Update(BaseVariableState variable, object value)
        {
            if (variable == null) throw new ArgumentNullException("variable");
            if (!object.Equals(variable.Value, value))
            {
                variable.Value = value;
                variable.Timestamp = m_timestamp;
                // SystemContext is a property in EmptyNodeManager
                variable.ClearChangeMasks(SystemContext, false);
            }
        }
