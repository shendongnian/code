    Master m=new Master();
	m.BList =new List<B>();
	
	B b=new B();
	b.FirstName ="ABC";
	b.Email="abc@abc.com";
	
	A a=new A();    //Line 1
	a.Rating = 1;
	a.Weightage =10;
	
	b.ListA.Add(a); //Line 2
	
	a.Rating = 2;   <--- problem here
	a.Weightage =20;
	
	b.ListA.Add(a); //Line 3
	m.BList.Add(b);
