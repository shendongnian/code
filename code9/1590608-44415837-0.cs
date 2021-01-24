    Int16 size = 0;
    try
    {
         size = Convert.ToInt16(textBox1.Text));
    }
    catch(FormatException)
    {
         // Handle exception
    }
    if(size > 0)
    {
         HR frm = new HR(size);
         frm.show();
         this.close();
    }
    else
    {
         // Handle error
    }
