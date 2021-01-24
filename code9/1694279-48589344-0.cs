    [ComVisible(true)]
    [Guid("E449B0E6-2F27-46B7-9CC0-C7032B7B5BF1")]
    public interface IclsHacienda
    {
        [DispId(1)]
        bool tengoAcceso();
    
        [DispId(2)]
        void configuracion(bool pBlnEnvioProduccion,
                     string pStrUsuarioHacienda,
                     string pStrClaveHacienda,
                    string pStrPinCerti,
                    string pStrRutaCerti,
                    string pStrRutaArchEnvio,
                    string pStrRutaArchRespuesta);
    
        [DispId(3)]
        string[] registrarDocElectronico(
                    string pStrVerificador,
                     byte pBytSituacionEnCom,
                     IDocumentoEncabezado pLstEncabezadoDoc
                    );
    }
    
    [ComVisible(true)]
    [Guid("97F8901F-EEDA-4DE1-8B4B-826ED43E17D8")]
    public interface IDocumentoEncabezado
    {
        int MyProperty { get; set; }
    }
