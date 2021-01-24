     public class PastAndOr:INotifyPropertyChanged
    {
        public Visibility _acikmi;
        public Visibility Acikmi
        {
            get {return _acikmi; }
            set
            {
                _acikmi = value;
                OnPropertyChaged(nameof(Acikmi));
            }
        }
        public int ID { get; set; }
        public string Adi { get; set; }
        public string SarjNo { get; set; }
        public string CreateDate { get; set; }
        public string ParcaKodu { get; set; }
        public string ParcaKoduAdi { get; set; }
        public string Malzeme { get; set; }
        public string MusteriKodu { get; set; }
        public string MusteriKoduAdi { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChaged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
