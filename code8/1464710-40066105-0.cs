    public class Clinica : ModelBase
    {
        private Dados _dados;
        public string Dados
        {
            get
            {
                return _dados;
            }
            set
            {
                _dados = value;
                RaisedPropertyChanged(() => Dados);
            }
        }
    }
    public class Dados
    {
        // properties for Nome, Latitude, Longitude
    }
