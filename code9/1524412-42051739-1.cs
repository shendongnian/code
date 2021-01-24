    static object MakeBoxed() {
    	int n = 5;
    	object a = n;
    	return a;
    }
	public static void Main() {
		for (int i = 0 ; i != 10 ; i++) {
			object a = MakeBoxed();
			Console.WriteLine(RuntimeHelpers.GetHashCode(a));
		}
	}
