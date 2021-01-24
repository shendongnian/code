    const int SUPP = 2;
    /* Calls the methods to execute the program
     * 
     * precondition: none
     * postcondition: returns a series of strings and integers
     */
    static void Main() {
        const int NUMBER_OF_ROWS = 9;
        int[,] lottoNumbers ={
                         { 4, 7, 19, 23, 28, 36 },
                         { 14, 18, 26, 34, 38, 45 },
                         { 8, 10,11, 19, 28, 30 },
                         { 15, 17, 19, 24, 43, 44 },
                         { 10, 27, 29, 30, 32, 41 },
                         { 9, 13, 26, 32, 37, 43 },
                         { 1, 3, 25, 27, 35, 41 },
                         { 7, 9, 17, 26, 28, 44 },
                         {17, 18, 20, 28, 33, 38 }
                          };
        int[] drawNumbers = new int[] { 44, 9, 17, 43, 26, 7, 28, 19 };
        TitleMessage();
        PrintYourNumbers(lottoNumbers);
        PrintDrawNumbers(drawNumbers);
        PrintChecks(lottoNumbers, drawNumbers, lottoNumbers.GetLength(0));
        ExitProgram();
    }//end Main
    /* Print welcome message
     * 
     * precondition: none
     * postcondition: returns the string
     */
    static void TitleMessage() {
        Console.WriteLine("\n\t Welcome to Lotto Checker \n\n\n");
    } //end TitleMessage
    /* Display the list of games created
     * 
     * precondition: list must be a two-dimentional array containing integers
     * postcondition: returns the list of games on separate lines (as strings)
     */
    static void PrintYourNumbers(int[,] list) {
        Console.WriteLine("Your Lotto numbers are:\n");
        for (int i = 0; i < list.GetLength(0); i++) {
            Console.Write("Game  {0,3}:", i + 1);
            for (int j = 0; j < list.GetLength(1); j++) {
                Console.Write("  {0,2}", list[i, j]);
            }
            Console.WriteLine("\n\n");
        }
    } //end PrintYourNumbers
    /* Display the single draw list created
    * 
    * precondition: list must be a two-dimentional array containing integers
    * postcondition: returns the draw list
    */
    static void PrintDrawNumbers(int[] list) {
        Console.WriteLine("\n\n Lotto Draw Numbers are: \n");
        for (int i = 0; i < list.Length; i++) {
            Console.Write("  {0,2}", list[i]);
        }
        Console.WriteLine("\n");
    } //end PrintDrawNumbers
    /* Display the string of winning numbers and sups
    * 
    * precondition: all parameters must be integers, yourNums must be 2D array,
    *                  drawNums must be single array, 
    *                  gameNum > 0 and < length of yourNums  
    * postcondition: returns the winning values on separate lines (as a string)
    */
    static void PrintWinners(int[,] yourNum, int[] drawNum, int gameNum) {
        int winningNum = 0, winningSup = 0;
        winningNum = CheckNumbers(yourNum, drawNum, gameNum);
        winningSup = CheckSups(yourNum, drawNum, gameNum);
        Console.WriteLine("\n\n\t found {0} winning numbers and {1} supplementary numbers in Game {2}\n\n", winningNum, winningSup, gameNum + 1);
    } //end CheckGame
    /* Compare game numbers against draw numbers
    * 
    * precondition: all parameters must be integers, yourNums must be 2D array,
    *                  drawNums must be single array, 
    *                  gameNum > 0 and < length of yourNums  
    * postcondition: returns the number of winning numbers
    */
    static int CheckNumbers(int[,] yourNum, int[] drawNum, int gameNum) {
        int winningNumber = 0;
        for (int i = 0; i < yourNum.GetLength(1); i++) {
            for (int j = 0; j < drawNum.Length - SUPP; j++) {
                if (yourNum[gameNum, i] == drawNum[j]) {
                    winningNumber++;
                }
            }
        }
        return winningNumber;
    } //end CheckNumbers
    /* Compare game sup numbers against draw numbers
    * 
    * precondition: all parameters must be integers, yourNums must be 2D array,
    *                  drawNums must be single array, 
    *                  gameNum > 0 and < length of yourNums  
    * postcondition: returns the number of winning sups
    */
    static int CheckSups(int[,] yourNum, int[] drawNum, int gameNum) {
        int winningSup = 0;
        for (int j = 0; j < yourNum.GetLength(1); j++) {
            for (int k = drawNum.Length - SUPP; k < drawNum.Length; k++) {
                if (yourNum[gameNum, j] == drawNum[k]) {
                    winningSup++;
                }
            }
        }
        return winningSup;
    } //end CheckSups
    /* Prints each game's winning numbers and sups
     * 
     * precondition: all parameters must be integers, yourNums must be 2D array,
     *                  drawNums must be single array, 
     *                  gameNum > 0 and < length of yourNums  
     * postcondition: prints each game's winning number & sup count
     */
    static void PrintChecks(int[,] yourNums, int[] drawNums, int gameNum) {
        for (int i = 0; i < gameNum; i++) {
            PrintWinners(yourNums, drawNums, i);
        }
    } //end PrintChecks
    /* Print exit message
     * 
     * precondition: none
     * postcondition: returns the string
     */
    static void ExitProgram() {
        Console.Write("\n\nPress any key to exit program: ");
        Console.ReadKey();
    }//end ExitProgram
