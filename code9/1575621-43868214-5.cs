    public class ListItem
    {
        ListItemPresenter m_Presenter;
    
        public ListItemPresenter GetPresenter()
        {
            return m_Presenter;
        }
    
        string m_ElementContent;
    
        public string ElementContent
        {
            get { return m_ElementContent; }
            set { m_ElementContent = value; }
        }
    
        public ListItem(ListItemPresenter presenter)
        {
            m_Presenter = presenter;
        }
    }
