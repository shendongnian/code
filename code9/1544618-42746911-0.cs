	    class UserControlOne
		{
			public void Update(Action updateAction)
			{
				updateAction();
			}
		}
		class UserControlTwo
		{
			public void Update()
			{
				Console.WriteLine("Updated");
				Console.ReadKey();
			}
		}
		class Program
		{
			static void Main(String[] args)
			{
				UserControlOne uc = new UserControlOne();
				UserControlTwo uc2 = new UserControlTwo();
				uc.Update(uc2.Update);
			}
		}
