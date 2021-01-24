    [XmlRoot("auxiliarA")]
    [XmlType("auxiliarA")]
    public class CampoAuxiliar
    {
        private string descripcionAuxiliar;
        private DateTime fechaAuxiliar;
        public CampoAuxiliar() { }
        [XmlElement(ElementName = "descripcionAuxiliar", Type = typeof(string))]
        public string DescripcionAuxiliar
        {
            get { return descripcionAuxiliar; }
            set { descripcionAuxiliar = value; }
        }
        [XmlElement(ElementName = "fechaHabilitacion", Type = typeof(DateTime))]
        public DateTime FechaAuxiliar
        {
            get { return fechaAuxiliar; }
            set { fechaAuxiliar = value; }
        }
        private ArrayList opcion;
        [XmlElement("opcion", Type = typeof(Opcion))]
        public ArrayList Opcion
        {
            get { return opcion; }
            set { opcion = value; }
        }
    }
