	//...
	featuresForVerification = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification); //since this appears unaffected by our profileDic values, let's initialise once
	if (featuresForVerification != null)
	{
		DPFP.Verification.Verification verificator = new DPFP.Verification.Verification();
		foreach (KeyValuePair<decimal, MemoryStream> tt in profileDic)
		{
			string key = tt.Key.ToString(); //we use this a lot, so let's only convert it to string once, then reuse that
			UIReportCurrentKey(key);
			temp = new DPFP.Template(tt.Value);	
			DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
			verificator.Verify(featuresForVerification, temp, ref result);
			UIReportMatch(result, key);
			//if a match were found, would we want to keep comparing, or exit on first match?  If the latter, add code to record which record matched, then use break to exit the loop
			UIIncremementProgressBar();
		}
	} else {
		throw new NoFeaturesToVerifyException("The verfication tool was not given any features to verify");
		//alternatively set progress bar to complete / whatever other UI actions you have /
		//whatever you want to happen if no features were selected for comparison
	}
	//...
	#region UI Updaters
	/*
		I don't know much about winforms updates; have a feeling these can be made more efficient too, 
		but for the moment just shoving the code into its own functions to make the main method less
		cluttered with UI logic.
	*/
	// Adds the key of the item currently being processed to the UI textbox
	private void UIReportCurrentKey(string key) 
	{
		this.Invoke(new Function(delegate()
		{
			textBox1.Text += "\n" + key;
		}));
	}
	private void UIReportMatch(DPFP.Verification.Verification.Result result, string key) 
	{
		if (result.Verified) 
		{
			this.Invoke(new Function(delegate()
			{
					MessageBox.Show("FAR " + result.FARAchieved + "\n" + key);
					//MessageBox.Show("No Match");
			}));
		} 
		/* 
		else 
		{
		
		} 
		*/
	}
	private void UIIncremementProgressBar() 
	{
		this.Invoke(new Function(delegate()
		{
			progressBar1.Value++;
		}));
	}
	#endregion UI Updaters
	#region Custom Exceptions
	public class NoFeaturesToVerifyException: ApplicationException 
	{ //Choose base class appropriately
		public NoFeaturesToVerifyException(): base() {}
		public NoFeaturesToVerifyException(string message): base(message) {}
		//...
	}
	#endregion Custom Exceptions
