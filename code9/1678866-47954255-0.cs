    View view;
    Label label;
    RadioButton RadioButtonA, RadioButtonB, RadioButtonC;
    foreach (DataRow dr in dt.Rows)
    {
    	view = new View();
    	label = new Label();
    	RadioButtonA = new RadioButton();
    	RadioButtonB = new RadioButton();
    	RadioButtonC = new RadioButton();
    	
    	label.Text = dr["qustion"].ToString();
    	RadioButtonA.Text= dr["cha"].ToString();
    	RadioButtonB.Text = dr["chb"].ToString();
    	RadioButtonC.Text = dr["chc"].ToString();
    	view.Controls.Add(label);
    	view.Controls.Add(RadioButtonA);
    	view.Controls.Add(RadioButtonB);
    	view.Controls.Add(RadioButtonC);
    	m1.Views.Add(view);
    }
