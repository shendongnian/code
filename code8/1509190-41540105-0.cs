    using System.Linq;
    using System.Collections.Generic;
    bool IsDateTimeListInAscendingOrder(List<DateTime> dateTimeList)
    {
		var previousDateTimeItem = dateTimeList.FirstOrDefault();
		foreach (DateTime currentDateTimeItem in dateTimeList)
		{
			if (currentDateTimeItem.CompareTo(previousDateTimeItem) < 0)
				return false;
		}
		return true;
	}
