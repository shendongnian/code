    public class SteelAssembly
    {
        public int LotNo { get; set; }
        public string AssemblyMark { get; set; }
        public string AssemblyName { get; set; }
        public string Part { get; set; }
        public int Quantity { get; set; }
        public string Profile { get; set; }
        public string Grade { get; set; }
        public decimal Length { get; set; }
        public decimal Weight { get; set; }
        public decimal Width { get; set; }
    
        public decimal UoM 
        {
            get
            {
                return Width == 0 ? (Quantity * Length) : (Quantity * Length * Width);
            }
        }
    }
