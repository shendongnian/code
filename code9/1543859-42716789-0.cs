		var k = "The Password for the website is money";
        // we remove the noise
		var password = k.Replace("The Password for the website is ", "");
        // we add the noise and we use a string constructor to duplicate the letter.
		Console.WriteLine("The Password for the website is " + new string('X', password.Length));
