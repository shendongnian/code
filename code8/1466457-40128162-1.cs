    public void ScoreCalc()
    {
        int counter = 1;
        int score = 0;
		String input;
        while (true)
        {
            Console.WriteLine("Enter a score");
            input=Console.ReadLine();
			if(input != "end"){
			score += int.Parse(input);
            Console.WriteLine(score + " " + counter);
            counter++;
			}else{
			break;
			}
        }
    }
