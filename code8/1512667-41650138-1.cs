	public Fish(int QTY){
       Initialize(QTY);
	}
	
	public void  Initialize(){
		Console.WriteLine("Fish.Initialize()");
       name = "fish";
       ID = 1;
       variant = 0;
       maxStack = 20;
	}
    public void Initialize(int QTY) {
		Console.WriteLine("Fish.Initialize(QTY)");
		Initialize();
		base.Initialize(QTY);		
	}
