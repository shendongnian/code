     namespace WebService.Models
    {
         [DataContract(Name = "VitalSigns")]
		public class VitalSignsDTO
		{
			[DataMember(Name = "id", Order = 1)]
			public int id { get; set; }
			[DataMember(Name = "name", Order = 2)]
			public string name { get; set; }
			[DataMember(Name = "valore", Order = 3)]
			public string valore { get; set; }
			[JsonIgnore]
			[DataMember(Name = "dataOra", Order = 3)]
			public DateTime? dataOra { get; set; }
		}
	}
