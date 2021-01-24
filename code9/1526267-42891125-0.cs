    /// <summary>
	/// Using the TestModel parameter, you can specify a Revit model
	/// to be opened prior to executing the test. The model path specified
	/// in this attribute is relative to the working directory.
	/// </summary>
	[Test]
	[TestModel(@"./bricks.rfa")]
	public void ModelHasTheCorrectNumberOfBricks()
	{
		var doc = RevitTestExecutive.CommandData.Application.ActiveUIDocument.Document;
		var fec = new FilteredElementCollector(doc);
		fec.OfClass(typeof(FamilyInstance));
		var bricks = fec.ToElements()
			.Cast<FamilyInstance>()
			.Where(fi => fi.Symbol.Family.Name == "brick");
		Assert.AreEqual(bricks.Count(), 4);
	}
