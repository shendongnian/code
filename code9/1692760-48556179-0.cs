    public FooDTO GetFoo()
        {            
            return new SampleLibrary.FooDTO() { Name = "Service A" };
        }
        
        public BarDTO GetBar()
        {
            //or add using SampleLibrary; definition begining of the pages 
            //and write just as BarDTO without SampleLibrary.BarDTO
            return new BarDTO() { Name = "Service A" };
        }
