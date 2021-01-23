    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //[InverseProperty( nameof( VariableSetting.Category ) )]
        public virtual ICollection<VariableSetting> VariableSettings { get; set; }
            = new List<VariableSetting>();
        //[InverseProperty( nameof( Station.Category ) )]
        public virtual ICollection<Station> Stations { get; set; } 
            = new List<Station>();
    }
    public class Station
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        //[InverseProperty( nameof( VariableRecord.Station ) )]
        public virtual ICollection<VariableRecord> VariableRecords { get; set; }
            = new List<VariableRecord>();
        [Required]
        public int CategoryId { get; set; }
        //[ForeignKey( nameof( CategoryId ) )]
        public virtual Category Category { get; set; }
    }
    public class VariableRecord
    {
        [Key]
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime RecordDate { get; set; }
        [Required]
        public int StationId { get; set; }
        //[ForeignKey( nameof( StationId ) )]
        public virtual Station Station { get; set; }
        [Required]
        public int VariableSettingId { get; set; }
        //[ForeignKey( nameof( VariableSettingId ) )]
        public virtual VariableSetting VariableSetting { get; set; }
    }
    public class VariableSetting
    {
        [Key]
        public int Id { get; set; }
        public int Sequence { get; set; }
        public double? MinimumValue { get; set; }
        public double? MaximumValue { get; set; }
        [Required]
        public int CategoryId { get; set; }
        //[ForeignKey( nameof( CategoryId ) )]
        public virtual Category Category { get; set; }
        [Required]
        public int VariableId { get; set; }
        //[ForeignKey( nameof( VariableId ) )]
        public virtual Variable Variable { get; set; }
        //[InverseProperty( nameof( VariableRecord.VariableSetting ) )]
        public virtual ICollection<VariableRecord> VariableRecords { get; set; }
            = new List<VariableRecord>();
    }
    public class Variable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        //[InverseProperty( nameof( VariableSetting.Variable ) )]
        public virtual ICollection<VariableSetting> VariableSettings { get; set; }
            = new List<VariableSetting>();
    }
