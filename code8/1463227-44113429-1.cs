		 class RootObject<T>
		 {
			public List<T> Value { get; set; }
		 }
		 
		 var odata  = JsonConvert.DeserializeObject<RootObject<POCO>>(json);
		 
