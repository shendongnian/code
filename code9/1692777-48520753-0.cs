    public class GreenCertificatesGroupModel
    {
        public IEnumerable<CertificatesTypeEnum> EnumValues { get; } 
            = Enum.GetValues(typeof(CertificatesTypeEnum)).Cast<CertificatesTypeEnum>();
        private CertificatesTypeEnum _selectedItem;
        public CertificatesTypeEnum SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; }
        }
    }
