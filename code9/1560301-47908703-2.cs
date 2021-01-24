    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    public class DataTableToModel
    {
        /// <summary>
        /// Deserialize from DataTable, set ModelProperty from first row
        /// </summary>
        [JsonProperty("Table")]
        private List<Model> ModelSetter { set { this.ModelProperty = value.FirstOrDefault(); } }
        /// <summary>
        /// Serialize Model
        /// </summary>
        [JsonProperty("Model")]
        public Model ModelProperty { get; set; }
    }
    /// <summary>
    /// Model that has id and value properties expected from DataTable
    /// </summary>
    public class Model 
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("value")]       
        public string value { get; set; }
    }
