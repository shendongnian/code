    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        //Getting first from base
        base.GetObjectData(info, context);
                               
        if (info != null)
        {
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                //Adding only properties that not already declared on Exception class
                if (property.DeclaringType.Name != typeof(Exception).Name)
                {
                    info.AddValue(property.Name, property.GetValue(this));
                }
            }
        }
    }
