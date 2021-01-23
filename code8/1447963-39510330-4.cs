    /// <summary>
    /// arcgis yapısına uygun token modelidir
    /// </summary>
    public class TokenModel
    {
        /// <summary>
        /// servisin dönüş tipini belirleyen fieldttır . ör ; json,html
        /// </summary>
        public string f { get; set; }
        /// <summary>
        /// servise gönderilecek kullanıcı adı bilgisi
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// servise gönderilecek olan şifre bilgisidir.
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// token bilgisinin hangi ip için geçerli olacağını bildirir
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// token bilgisinin ne kadar süreli olacağını belirtir
        /// </summary>
        public int expiration { get; set; }
        /// <summary>
        /// servis client bilgisi
        /// </summary>
        public string client { get; set; }
        /// <summary>
        /// constructure
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="ip"></param>
        /// <param name="expiration"></param>
        /// <param name="f"></param>
        public TokenModel(string username, string password, string ip, int expiration, string f = "json")
        {
            this.expiration = expiration;
            this.f = f;
            this.ip = ip;
            this.password = password;
            this.username = username;
        }
        /// <summary>
        /// modelin query string halinde dönüşünü sağlar
        /// </summary>
        /// <returns></returns>
        public string GetQueryStringParameter()
        {
            return "f=" + this.f + "&username=" + this.username + "&password=" + this.password + "&ip=" + this.ip + "&expiration=" + this.expiration;
        }
    }
