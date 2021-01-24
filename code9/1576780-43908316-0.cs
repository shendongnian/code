    var sentence = "dancing sentence";
    var charSentence = sentence.ToCharArray();
    var rs = "";
    var flag = true;
    for (var i = 0; i < charSentence.Length; i++)
    {
    
    	if (charSentence[i] != ' ')
    	{
    		if (flag)
    		{
    			rs += charSentence[i].ToString().ToUpper();
    		}
    		else
    		{
    			rs += sentence[i].ToString().ToLower();
    		}
    		flag = !flag;
    	}
    	else
    	{
    		rs += " ";
    	}
    }
    Console.WriteLine(rs);
