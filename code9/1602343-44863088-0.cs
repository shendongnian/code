    public class DummyBook
    {
        #region Properties
        private string _name;
        private string _author;
        private string _publishedDate;
        private string _publisher;
        private string _pageCount;
        private string _language;
        private string _additionalInfo;
        private string _coverFrontURL;
        private string _coverBackURL;
        private string _thumbURL;
        #endregion
        #region Getters and Setters
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        public string PublishedDate
        {
            get { return _publishedDate; }
            set { _publishedDate = value; }
        }
        public string Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }
        public string PageCount
        {
            get { return _pageCount; }
            set { _pageCount = value; }
        }
        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }
        public string AdditionalInfo
        {
            get { return _additionalInfo; }
            set { _additionalInfo = value; }
        }
        public string CoverFrontURL
        {
            get { return _coverFrontURL; }
            set { _coverFrontURL = value; }
        }
        public string CoverBackURL
        {
            get { return _coverBackURL; }
            set { _coverBackURL = value; }
        }
        public string ThumbURL
        {
            get { return _thumbURL; }
            set { _thumbURL = value; }
        }
        #endregion
    }
