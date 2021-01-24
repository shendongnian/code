	private static TextBox tb;
	private void Form1_Load(object sender, EventArgs e)
	{
		tb = this.textBox3;
	}
	private static void Anonymize(ElementList elementList)
	{
		string name = tb.Text;
		Anonimize(elementList.Get(DicomTag.PatientsName), PatientNames, "Patient Name " + name);
	}
