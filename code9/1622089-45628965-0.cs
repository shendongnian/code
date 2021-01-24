	public void SolveProblem(DayOfWeek day, ClassAbstract c)
	{
		//Problem solved. I need to call "CallThisMethod" who called this helper class
		//How to I Call
		switch (day)
		{
			case DayOfWeek.Sunday:
			case DayOfWeek.Saturday:
				c.WeekEndOperation();
				break;
			case DayOfWeek.Friday:
				FridayOperations();
				break;
			default:
				c.WeekDayOperation();
				break;
		}
	}
