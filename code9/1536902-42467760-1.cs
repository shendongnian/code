    public class MyMainClass
    {
		public MyMainClass()
		{
			sub1 = new subClass1();
			sub2 = new subClass2(sub1);
		}
        public subClass1 sub1;
        public subClass2 sub2;
        public class subClass1
        {
            public string sb1A{get;set;}
            public string sb1B{get;set;}
        }
        public class subClass2
        {
			public subClass2(subClass1 sub1)
			{
				this.sub1 = sub1;
			}
            public string sb2A{get;set;}
            public string sb2B{get;set;}
            subClass1 sub1;
            public string wantPassString {get{return "I've got value " + sub1.sb1A;}}
        }
    }
