	private void buttonPopupdEnabled_Click(object sender, EventArgs e)
	{
		WatiN.Core.Settings.Instance.MakeNewIeInstanceVisible = false;
		IE ie = new IE();
		ie.GoTo("http://zikro.gr/dbg/html/watin-disable-popups/");
		ie.Eval("window['open'] = function() { return false; }");
		ie.TextField(Find.ById("numA")).TypeText("15");
		ie.TextField(Find.ById("numB")).TypeText("21");
		ie.Button(Find.ById("sum")).Click();
		string result = ie.Span(Find.ById("result")).Text;
		ie.Close();
		labelResult.Text = String.Format("The result is {0}", result);
	}
