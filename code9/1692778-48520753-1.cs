    public class GreenCertificatesGroupModel
    {
        public IEnumerable<CertificatesTypeEnum> EnumValues
        {
            get
            {
                var list = Enum.GetValues(typeof(CertificatesTypeEnum)).Cast<CertificatesTypeEnum>();
                return list;
            }
        }
        private CertificatesTypeEnum _selectedItem;
        public CertificatesTypeEnum SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; }
        }
    }
