    class MyForm : Form
    {
    private Producer producer;
	
	public MyForm()
	{
		producer = new Producer();
		producer.YSeriesEvent += MyHandler ;
		Load+= (sender, args) => producer.Start();
	}
	
	private void MyHandler(object o, double val)
	{
		Invoke(new Action(() =>
		{
               //add value to chart here
		}));
	}
    }   
