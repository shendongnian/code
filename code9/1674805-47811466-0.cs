	public List<ListTnc> GetNewTncs()
	{
		List <ListTnc> listTncs = new List<ListTnc>();
		List<SuppressionVariant> variants = SuppressionVariants.Include("SuppressionList).ToList();
		foreach (var suppressionList in SuppressionLists.Where(sl => sl.RequireTnc))
		{
			if (variants.Any(d => d.ListName == suppressionList.ListName))
			{
				listTncs.Add(new ListTnc { SuppressionListId = variants.Where(d => d.ListName == suppressionList.ListName)
								.FirstOrDefault().SuppressionList.SuppressionListId });
			}
			else
			{
				listTncs.Add(new ListTnc { SuppressionListId = suppressionList.SuppressionListId });
			}
		}
		return listTncs;
	}
