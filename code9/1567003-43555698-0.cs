    class person
        {
        	public void add(int x, int y) => Console.WriteLine(x + y);
        	public void sub(int x, int y) => Console.WriteLine(x - y);
        	public void mul(int x, int y) => Console.WriteLine(x * y);
        	public void test(Action<int, int> ad1) => ad1(2, 3);
        
        }
        class Program
        {
        	static void Main(string[] args)
        	{
        		person p = new person();
        		Action<int, int> action = (x, y) => {};
        		if (DateTime.Now.Hour < 12)
        		{
        			action = p.add;
        		}
        		else if (DateTime.Now.Hour < 20)
        		{
        			action = p.sub;
        		}
        		p.test(action);
        	}
        }
