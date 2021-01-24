    public  class ContextFactory  
    {
       public static SourceContext ObtainContext()
       {
            SourceContext context = null;
            string key = Thread.CurrentContext.ContextID.ToString();
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(key);
            if (slot != null)
            {
                context = (SourceContext)Thread.GetData(slot);
            }
            if (context == null)
            {
                context = new SourceContext();
                if (slot == null)
                {
                    slot = Thread.AllocateNamedDataSlot(key);
                }
                Thread.SetData(slot, context);
            }
            return context;
        }
       }
    }
