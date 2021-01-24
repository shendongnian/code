			Parallel.ForEach(links, new ParallelOptions { MaxDegreeOfParallelism = 25 },
				webpage =>
				{
					try
					{
						if (WebPageValidator.ValidUrl(webpage))
						{
							string linkToProcess = webpage;
							if (links.TryDequeue(out linkToProcess) && !Visitedlinks.Contains(linkToProcess))
							{
								Task obj = Scrape(linkToProcess);
								Visitedlinks.Enqueue(linkToProcess);
							}
						}
					}
					catch (Exception e)
					{
						log.Error("Error occured: " + e.Message);
						Console.WriteLine("Error occured, check log for further details.");
					}
