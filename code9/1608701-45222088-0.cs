    	public async Task FindMyFile(string filePath)
		{			
			int retries = 0;
			this.Founded = false;
			while (!this.Founded)
			{
				if (System.IO.File.Exists(filePath))
					this.Founded = true;
				else if (retries < this.maxTries)
				{
					Console.WriteLine($"File {filePath} not found. Going to wait for 15 minutes");
					await Task.Delay(new TimeSpan(0, 15, 0));
					++retries;
				}
				else
				{
					Console.WriteLine($"File {filePath} not found, retries exceeded.");
					break;
				}
			}
		}
