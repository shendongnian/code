	public string ReturnFinalOutput(string InputJson)
	{
		List<fromJson> input = JsonConvert.DeserializeObject<List<fromJson>>(InputJson);
		List<final_out> output = new List<final_out>();
		foreach (fromJson j in input)
		{
			final_out o = new final_out();
			var finalout = output.FirstOrDefault<final_out>(a => a.type == j.type);
			if (finalout == null)
			{
				o.type = j.type;
				if (j.category == "healthy")
				{
					o.healthy = o.healthy + 1;
				}
				else if (j.category == "unhealthy")
				{
					o.unhealthy = o.unhealthy + 1;
				}
				output.Add(o);
			}
			else
			{
				output.Remove(finalout);
				if (j.category == "healthy")
				{
					finalout.healthy = finalout.healthy + 1;
				}
				else if (j.category == "unhealthy")
				{
					finalout.unhealthy = finalout.unhealthy + 1;
				}
				output.Add(finalout);
			}
		}
		return JsonConvert.SerializeObject(output);
	}
    
