    [ComVisible(true)]
    [Guid("4726F93F-D102-442E-AF7D-3255B87E740C")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(IDocumentoEncabezado))]
    public class DocumentoEncabezado : IDocumentoEncabezado
    {
        public int MyProperty { get; set; }
    }
    [ComVisible(true)]
    [Guid("500941FB-3F7B-4285-BF4A-A642D60AD923")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(IclsHacienda))]
    public class ClsHacienda : IclsHacienda
    {
        public void configuracion(bool pBlnEnvioProduccion, string pStrUsuarioHacienda, string pStrClaveHacienda, string pStrPinCerti, string pStrRutaCerti, string pStrRutaArchEnvio , string pStrRutaArchRespuesta)
        {
            Debug.WriteLine("Called configuracion");
        }
        public string[] registrarDocElectronico(string pStrVerificador, byte pBytSituacionEnCom, IDocumentoEncabezado pLstEncabezadoDoc)
        {
            Debug.WriteLine("Called registrarDocElectronico");
            return new string[] { "Whatever" };
        }
        public bool tengoAcceso()
        {
            Debug.WriteLine("Called tengoAcceso");
            return false;
        }
    }
