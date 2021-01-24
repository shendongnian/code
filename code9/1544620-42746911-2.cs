		class UserControlOne
		{
			public void Update(Action updateAction = null)
			{
				updateAction?.Invoke(); # you could also write updateAction();
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
				// calling exmaple 1
				UserControlOne uc = new UserControlOne();
				UserControlTwo uc2 = new UserControlTwo();
				uc.Update(uc2.Update);
				// calling example 2
				UserControlOne anotherUserControl = new UserControlOne();
				anotherUserControl.Update();
			}
		}
