        class MyViewModel
        {
            List<string> MyList { get; set; } //Your list that you need right now
            string PropertyThatCanBeAddedInFuture { get; set; }
        }
        [HttpPost]
        public MyViewModel Index(string txtJsonIn)
        {
            return new MyViewModel(); 
        }
