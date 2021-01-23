     public class MathProblem
    {
        private Random random = new Random();
        private int num1, num2, sum;
        public virtual void SetProblem()
        {
            num1 = random.Next(100);
            num2 = random.Next(100);
            sum = num1 + num2;
        }
        public virtual void AskUserForAnswer()
        {
            int answer;
            Console.WriteLine("Enter your answer");
            answer = Convert.ToInt32(Console.ReadLine());
        }
        public virtual void DisplayProblem()
        {
            Console.WriteLine( num1.ToString() + " + " + num2.ToString() + " = ?");
            
        }       
    }
