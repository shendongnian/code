    public class TestClass
    {
        public int ID { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.#}")]
        public decimal DecimalProperty { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.#}")]  
        public decimal SecondDecimalProperty { get; set; }
    }
    @Html.EditorFor(model => model.DecimalProperty)
