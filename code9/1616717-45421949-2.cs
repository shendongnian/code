    public class RequestObject {
        public string str2;
        public string str;
    }
 
    [WebMethod]
    public static string EncritaDados(RequestObject request)
    {
        return  Verificacoes.EncryptString(request.str)+";"+ Verificacoes.EncryptString(request.str2);
    }
