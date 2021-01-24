    class Program
        {
            static void Main(string[] args)
            {
                int num, sum = 0, r;
                Console.WriteLine("Enter a Number : ");
                num = int.Parse(Console.ReadLine());
                while (num != 0)
                {
                    /* Important: The logic behind is to add the numbers from the last one
                     * to the first one.
                     * 
                     * For example, 123 will be added in this way: 3 + 2 + 1
                     * We will use number 123 as example.*/
    
                    /* Comment: 
                     * 
                     * 1st run: 123 % 10, remainder will be 3. Anything modulus 10 will 
                     * always get the final digit. Now, we have r = 3, which will be used 
                     * in the final sum below.
                     * 
                     * 2nd run: 12 % 10, remainder will be 2. Now, we have r = 2, which 
                     * will be used in the final sum below.
                     * 
                     * 3rd run: 1 % 10, remainder will be 1. Now, we have r = 1, which will 
                     * be used in the final sum below.
                     */
                    r = num % 10;
    
                    /* Comment: 
                     *
                     * 1st run: 123 / 10, answer will be 12. If you are wondering why it 
                     * isn't 12.3, then it is because the datatype in used is "int", so the 
                     * answer will always be a round number, so 12.3 in round number will 
                     * be 12, which is the 2 numbers that have not been added, so now, 
                     * num = 12, and we have managed to discard 3 because we no longer need 
                     * it because it will be added in the final sum below.
                     * 
                     * 2nd run: 12 / 10, again answer is not 1.2, but num = 1. 
                     * We have managed to discard 2 because we no longer need it because it 
                     * will be added in the final sum below.
                     * 
                     * 3rd run: 1 / 10, again answer is not 0.1, but num = 0. 
                     * We have managed to discard 1 because we no longer need it because it 
                     * will be added in the final sum below. This will be the final run.
                     */
                    num = num / 10;
                    
                    /* Comment: 
                     * 1st run: 0 + 3 (1st run remainder)
                     * 2nd run: 3 + 2 (2nd run remainder)
                     * 3rd run: 5 + 1 (3rd run remainder)
                     */
                    sum = sum + r;
                }
                Console.WriteLine("Sum of Digits of the Number : " + sum);
                Console.ReadLine();
            }
        }
