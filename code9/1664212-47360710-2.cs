    .method private hidebysig static 
		void Main () cil managed 
	{
		// Header Size: 12 bytes
		// Code Size: 136 (0x88) bytes
		// LocalVarSig Token: 0x11000001 RID: 1
		.maxstack 3
		.entrypoint
		.locals init (
			[0] class [mscorlib]System.Collections.Generic.List`1<class ConsoleApp1.Program/Printer> printers,
			[1] class ConsoleApp1.Program/'<>c__DisplayClass1_0' 'CS$<>8__locals0', //There is only one variable of your class that has method that is going to be invoked. You do not have 10 unique methods. 
			[2] int32,
			[3] bool,
			[4] valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class ConsoleApp1.Program/Printer>,
			[5] class ConsoleApp1.Program/Printer printer
		)
		
	      IL_0007: newobj    instance void ConsoleApp1.Program/'<>c__DisplayClass1_0'::.ctor() //your class that is going to be used by delegate is created here
		  IL_000C: stloc.1 //and stored in local variable at index 1
		  /*(...)*/
		  IL_000E: ldc.i4.0 //we are putting 0 on stack
		  IL_000F: stfld     int32 ConsoleApp1.Program/'<>c__DisplayClass1_0'::i //and assign 0 to variable i which is inside this private class.
		// loop start (head: IL_003B)
			  /*(...)*/
			  IL_0019: ldftn     instance void ConsoleApp1.Program/'<>c__DisplayClass1_0'::'<Main>b__0'() //It push pointer to the main function of our private nested class on the stack.
			  IL_001F: newobj    instance void ConsoleApp1.Program/Printer::.ctor(object, native int) //We create new delegate which will be pointing on our local DisplayClass_1_0
			  IL_0024: callvirt  instance void class [mscorlib]System.Collections.Generic.List`1<class ConsoleApp1.Program/Printer>::Add(!0) //We are adding delegate
			  /* (...) */
			  IL_002C: ldfld     int32 ConsoleApp1.Program/'<>c__DisplayClass1_0'::i //loads i from our local private class into stack
			  IL_0031: stloc.2 //and put it into local variable 2
			  IL_0033: ldloc.2 //puts local variable at index 2 on the stack
			  IL_0034: ldc.i4.1 // nputs 1 onto stack
			  IL_0035: add //1 and local varaible 2 are being add and value is pushed on the evaluation stack
			  IL_0036: stfld     int32 ConsoleApp1.Program/'<>c__DisplayClass1_0'::i //we are replacing i in our instance of our private class with value that is result of addition one line before.
			  //This is very weird way of adding 1 to i... Very weird. Maybe there is a reason behind that
			  /* (...) */
		// end loop
		 /* (...) */
		.try
		{
			  /* (...) */
			// loop start (head: IL_0067)
				  /* (...) */
				  IL_0056: call      instance !0 valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class ConsoleApp1.Program/Printer>::get_Current() //gets element from list at current iterator position
				  /* (...) */
				  IL_0060: callvirt  instance void ConsoleApp1.Program/Printer::Invoke() //Invokes your delegate.
				  /* (...) */
			// end loop
			  IL_0070: leave.s   IL_0081
		} // end .try
		finally
		{
			  /* (...) */
		} // end handler
		  IL_0081: call      string [mscorlib]System.Console::ReadLine()
			/* (...) */
	} // end of method Program::Main
