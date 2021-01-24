    while((SingleNumb = sr.ReadLine()) != null)
    {
        NumberStyles style = NumberStyles.Any;
        CultureInfo culture = CultureInfo.InvariantCulture;
    
        float value = 0.0f;
        if (float.TryParse(SingleNumb, style, culture, out value))
        {
    	    MessageBox.Show(value.ToString());
        }
        else
        {
        	MessageBox.Show("Conversion failed!");
        }
    }
