    public abstract class Message<T>
    {
        protected int m_id;
        protected bool m_localized;
        protected string m_metaData;
        public int GetID() { return m_id; }
        public bool GetLocalized() { return m_localized; }
        public string GetMetadata() { return m_metaData; }
        public abstract T GetContent();
    }
    public class ClassicMessage : Message<string>
    {
        private string m_title;
        private string m_content;
        public void SetTitle(string title) { m_title = title; }
        public void SetContent(string content) { m_content = content; }
        public string GetTitle() { return m_title; }
        public override string GetContent()
        {
            return m_content;
        }
    }
    public class MessageWithCustomContent : Message<List<CustomContent>>
    {
        private List<CustomContent> m_content;
        public MessageWithCustomContent()
        {
            m_content = new List<CustomContent>();
        }
        public CustomContent GetCustomContent(int id)
        {
            return null;
        }
        public override List<CustomContent> GetContent()
        {
            return m_content;
        }
    }
    public class CustomContent
    {
        private int m_id;
        public int ID { get; set; }
        private string m_body;
        public string Body
        {
            get { return m_body; }
            set { m_body = value; }
        }
    }
