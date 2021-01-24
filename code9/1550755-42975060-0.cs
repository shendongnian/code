    internal static void TrackInfo(object sender, SqlInfoMessageEventArgs e)
	{
		Debug.WriteLine(e.Message);
		foreach (var element in e.Errors) {
			Debug.WriteLine(element.ToString());
		}
	}
