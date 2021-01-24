    public List<Member> GetMergedList()
	{
		var results = new List<Member>();
		
		for (int i=0; i<nameList.Count; i++)
		{
			results.Add(
				new Member
				{
					Name = nameList[i],
					Week = weekList[i],
					Discount = discountList[i],
					Charge = chargeList[i]
				}
			);
		}
		return results;
	}
