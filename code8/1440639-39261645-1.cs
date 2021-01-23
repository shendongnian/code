    public void heightAndWeight()
        {
            double height = getValue("What is your height in inches?");
            double weight = getValue("What is your weight in kilograms?");
            if (height > 0 && weight > 0)
            {
                Console.WriteLine("your BMI is " + (height * weight).ToString("N2"));
            }
        }
        private double getValue(string question) {
            double ret = 0;
            while(ret==0){
                Console.WriteLine(question);
                string retStr = Console.ReadLine();
                if(double.TryParse(retStr,out ret))
                {
                    return ret;
                }else{
                    Console.WriteLine("Invalid entry. Please try again");
                }
            }
            return ret;
        }
