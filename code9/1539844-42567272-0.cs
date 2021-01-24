    1. Sword() is called
    2. Console.WriteLine(...) is called multiple times to display options.
    3. swordChoice() is called.
       \\within swordChoice()
       4. Console.ReadLine() is called to retrieve users answer.
          (Undesired input so it falls to the default case) 
       5. Console.WriteLine() is called.
       6. swordChoice() is called.
          \\within swordChoice() #2
          7. Console.ReadLine() is called to retrieve users answer.
           (Assuming a desired input is entered. Case 3, just because. )
          8. Console.WriteLine();
          9. Console.ReadLine();
            (breaks from the statement in case "3")
          10. room3() is called the first time.
              \\within room3()
              11. Console.WriteLine ("You made it back.");
              12. Console.ReadLine ();
              \\function is completed so it returns to where it was called, which was just before the break in the default case
       (breaks from the statement in the default case)
       13. room3() is called the second time.
           \\within room3() #2
           14. Console.WriteLine ("You made it back.");
           15. Console.ReadLine ();
