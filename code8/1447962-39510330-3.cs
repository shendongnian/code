    /// <summary>
    /// acgis'e yapılan token isteme isteği sonunda elde edilen json'a ait modeldir
    /// </summary>
    public class ArcgisTokenResponseModel
    {
        /// <summary>
        /// token bilgisi
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// token bilgisinin geçerlilik süresi
        /// </summary>
        public string expires { get; set; }
    }
