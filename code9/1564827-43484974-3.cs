    String tb1 = Convert.ToInt32(textbox1.text);
    String tb2 = Convert.ToInt32(textbox2.text);
    If ((tb1 - tb2)==100 ||(tb1 - tb2)==250)
    {
        Int counter=0;
    	For (long i= tb2;i < tb1;i++)
    	{
            If (Listbox.Items.Contains(i)) {
                counter++;
                Listbox.Items.Remove(i);
            }
    	}
    }
    Console.WriteLine(counter + " items were removed");
