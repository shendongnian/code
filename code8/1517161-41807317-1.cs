    public void Send(ITelemetry item)
    {
        if (item is DependencyTelemetry)
        {
            var dependency = item as DependencyTelemetry;  
            if (dependency.DependencyTypeName == "SQL")  
            {  
                return;
            }  
        }        
        this.channel.Send(item);
    }
