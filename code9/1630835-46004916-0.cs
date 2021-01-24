    public class NoContaDigital
    {
        [XmlElement(IsNullable = false)]
        [Required(ErrorMessage = "Required")]
        [StringLength(2,ErrorMessage="Tamanho do campo excede limite.")]
        public string NroEmpresa { get; set; }
    } 
