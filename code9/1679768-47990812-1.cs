     case ConsoleKey.DownArrow:
              if (answerIndex + 1 <= options.Count - 1)
              {
                   // Rewrite selection in white
                   WriteOptionLine(currentAnswerTop, indent, options.Values.ElementAt(answerIndex), ConsoleColor.White);
                   WriteOptionLine(currentAnswerTop + 1, indent, options.Values.ElementAt(answerIndex + 1), ConsoleColor.Yellow);
                   currentAnswerTop += 1;
                   answerIndex += 1;
              }
              break;
