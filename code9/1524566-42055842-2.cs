    public abstract class Message 
    {
        protected int m_id;
        protected bool m_localized;
        protected string m_metaData;
    
        public virtual int GetID() { return m_id; }
        public virtual bool GetLocalized() { return m_localized; }
        public abstract string GetMetadata();
    }
