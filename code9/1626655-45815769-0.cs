	Chart1.Titles.Add("Case");
	Chart1.DataSource = dt;
	Series s = new Series();
	s.XValueMember = Convert.ToString(x);
	s.YValueMembers = Convert.ToString(y);
	//one line that you're missing
	Chart1.Series.Add(s);
	Chart1.DataBind();
