    [Table("dog_breed")]
    public DogBreed (){
        public int ID { get; set; }
        public string DogBreedName { get; set; }
        public List<PairMedicineDisease> PairsMedicineDisease { get; set; }
    }
    [Table("medicine")]
    public Medicine (){
        public int ID { get;set; }
        public string MedicineName { get;set; }
    }
    [Table("disease")]
    public Disease (){
        public int ID { get;set; }
        public string DiseaseName { get;set; }
    }
    [Table("pair_medicine_disease")]
    public PairMedicineDisease (){
        public int ID { get;set; }
        public Disease Disease { get;set; }
        public Medicine Medicine { get;set; }
    }
