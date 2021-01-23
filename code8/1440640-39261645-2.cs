    public void heightAndWeight()
        {
            double height = getValue("What is your height in inches?",36,80);
            double weight = getValue("What is your weight in kilograms?",45,135);
            if (height > 0 && weight > 0)
            {
                Console.WriteLine("your BMI is " + (height * weight).ToString("N2"));
            }
        }
        private double getValue(string question,int lowRange,int highRange) {
            double ret = 0;
            while(ret==0){
                Console.WriteLine(question);
                string retStr = Console.ReadLine();
                if(double.TryParse(retStr,out ret))
                {
                    if(ret<lowRange||ret>highRange){
                       Console.WriteLine("You must enter a value between "+lowRange.ToString()+" and "+highRange.ToString()+". Please try again.");
                       ret=0;
                     }else{
                        return ret;
                     }
                }else{
                    Console.WriteLine("Invalid entry. Please try again");
                }
            }
            return ret;
        }
