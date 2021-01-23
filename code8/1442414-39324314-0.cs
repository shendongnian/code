               double answer = 0;
               int correctAnswer = Convert.ToInt32(answer);
    
                      for (correctAnswer = 0; correctAnswer <= answer; correctAnswer++) ;
    
                        ///Setting up the switch statement
                        ///switch (variable)
                        ///      case 1:
                        ///      code;
                        ///      break;
                        ///      
                        switch (opSign)
                        {
                            case 1:
                                Console.WriteLine("What is the answer to " + num1 + (" Times " + num2 + " ?"));
                                answer = Convert.ToInt32(Console.ReadLine());
                                if (answer == num1 * num2)
                                {
    
                                    speechAnswers();
                                    Console.WriteLine("You entered " + answer + " as the answer to " + num1 + " times " + num2 + "." + " You are correct good job! ");
				                    score += 1; // every time the answer is corrent, score is incremented by 1.
                                }
                                else if (answer != num1 * num2)
                                    Console.WriteLine("You are incorrect please try again");
				             // what happens on loss
                                break;
