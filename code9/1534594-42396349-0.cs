    class Parent 
    {
        public int ParentId { get; set; }
		
		public void Eat { ... }
    }
    class Child : Parent
    {
        public int ChildId { get; set; }
		
		public void Play { ... }
    }
	
	Parent child = new Child();
	child.Eat(); // this makes sense since this is common functionality
	
	Child parent = new Parent();
	parent.Play() // this does not make sense since a Parent doesn't know hot to play
