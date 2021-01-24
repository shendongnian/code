using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
public class App
{
    interface IMessages {
    	string Welcome{ get; }
        string Goodbye { get; }
    }       
        
    partial struct EnglishMessages : IMessages {        
        public string Welcome {
            get { return "Welcome"; }
        }
        public string Goodbye {
            get { return "Goodbye"; }
        }
    }
    
    partial struct SpanishMessages : IMessages {        
        public string Welcome {
            get { return "Bienvenido"; }
        }
        public string Goodbye {
            get { return "Adios"; }
        }
    }
    
	static partial class Messages
    {
        public static SpanishMessages BuildLang {
            get { return default; }
        }
    }
    
    public static void Main() {
        Console.WriteLine(Messages.Welcome);
        Console.WriteLine(Messages.Goodbye);
    }
    
    static partial class Messages
    {   
        public static string Welcome {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
        	get { return GetWelcomeFrom(BuildLang); }
        }
        
        public static string Goodbye {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
        	get { return GetGoodbyeFrom(BuildLang); }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetWelcomeFrom<T>()
            where T : struct, IMessages
        {
           var v = default(T);
           return v.Welcome;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetWelcomeFrom<T>(T _)
            where T : struct, IMessages
        {
			return GetWelcomeFrom<T>();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetGoodbyeFrom<T>()
            where T : struct, IMessages
        {
           var v = default(T);
           return v.Goodbye;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetGoodbyeFrom<T>(T _)
            where T : struct, IMessages
        {
			return GetGoodbyeFrom<T>();
        }
        
    }
#region
    [StructLayout(LayoutKind.Explicit, Size = 0)]
    partial struct EnglishMessages { [FieldOffset(0)] int _;  }
    
    [StructLayout(LayoutKind.Explicit, Size = 0)]
    partial struct SpanishMessages { [FieldOffset(0)] int _;  }
#endregion
}
<br>
### You can able to understand the tricks with this code:
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
public class App
{
    interface IMessage {
    	string Value { get; }
        bool IsError { get; }
    }   
    
    static class Messages
    {
        // AggressiveInlining increase the inline cost threshold,
        // decreased by the use of generics.
        //
        // This allow inlining because has low cost,
        // calculated with the used operations.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetValue<T>()
            where T : struct, IMessage
        {
           // Problem:
           //  return default(T).Value
           //
           // Creates a temporal variable using the CIL stack operations.
           // Which avoid some optimizers (like coreclr) to eliminate them.
           
           // Solution:
           // Create a variable which is eliminated by the optimizer
           // because is unnecessary memory.
           var v = default(T);
           return v.Value;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsError<T>()
            where T : struct, IMessage
        {
           var v = default(T);
           return v.IsError;
        }
    }
    
    // The use of partial is only to increase the legibility,
    // moving the tricks to the end
    partial struct WelcomeMessageEnglish : IMessage {        
        public string Value {
            get { return "Welcome"; }
        }
        public bool IsError {
            get { return false; }
        }
    }
    
    partial struct WelcomeMessageSpanish : IMessage {        
        public string Value {
            get { return "Bienvenido"; }
        }
        public bool IsError {
            get { return false; }
        }
    }
   
    
    public static void Main() {
        Console.WriteLine(Messages.GetValue<WelcomeMessageEnglish>() );
        Console.WriteLine(Messages.GetValue<WelcomeMessageSpanish>() );
    }
    
// An struct has Size = 1 and is initializated to 0
// This avoid that, setting Size = 0
#region
    [StructLayout(LayoutKind.Explicit, Size = 0)]
    partial struct WelcomeMessageEnglish { [FieldOffset(0)] int _;  }
    
    [StructLayout(LayoutKind.Explicit, Size = 0)]
    partial struct WelcomeMessageSpanish { [FieldOffset(0)] int _;  }
#endregion
}
I "tested" this in CoreClr, Roslyn, Mono and the abstraction has "zero cost":
App.Main()
    L0000: push ebp
    L0001: mov ebp, esp
    L0003: mov ecx, [0xfd175c4]
    L0009: call System.Console.WriteLine(System.String)
    L000e: mov ecx, [0xfd17628]
    L0014: call System.Console.WriteLine(System.String)
    L0019: pop ebp
    L001a: ret
For coreclr and roslyn, you can view the asm in SharpLab: [Here](https://sharplab.io/#v2:C4LghgzgtgPgAgJgIwFgBQcAMACOSB0ASgK4B2wAllAKb4DCA9lAA4UA21ATgMpcBuFAMbUIAbnRZcBEuSq0AkuS4NmvTgOFj0EgMy4E2AILNm6AN7psV7BSWcAZmGHZ5AWREQwAc2rYLaa2wASDwcADUwNmJfM2wfYFFsAF9LQOsAIwYGNhcIAFFOTgZOPzjqBOTUqyTrKuw6vAA2fWx3CE8fCDr/NOsAej6jLy9ODwo+akU2W1svG1JBUchfYAALX1tp0l9BBghgbDXRiFXsgBMAGjrAgewz6kXqZbPsdIBPQ/XsYghfBnsyttOEIIPhrv0+uCrLcACqrCgQbCRNgMADu8y2s1eDzAP18q0g2BR6N2+yuAV62FugkigmIbDAwGoL1RFDWn18eJeKi4jIoDFIoKh2AA2u41gwzvIWGwABTi05SmUAeWYlAFoMMw2OEHGk1ImNIXgAlABdYVwPRNKQ4ADi5QiUWoAB4YQA+WXG4WBVHrUbYGHYEDYfacYiCYAXFxtDrUYU9SkQ7AABSK6Q4UBA3uhg1wAHY7tRHPTgLKYcb8I7otmqZCKYna9g6EsmYiwIdqCxipFsHwwMCwOnfJI1r46PIADIh4BOADW2B5nD5GrB9cTtwA6vDBKskXAACwhph/NVUCgALy4iNl01nO2KDzYnGNhwY2Go0ygtkZK3WUFXDZWDWtzcNkxDqqQWZrpStzNk8TJIr2/YUIOHDYL6Qi7gi76ft+TIvO8HILqeX6XpwwGDOkOJ4jYiL3GALy7PcAGAX2JR8NgAC8hbFmwpbluI0G9HABb3Lx/EVlW1CCYmKRCUB8migqkrSswcrKUqamqhBmramMExTDMRpmhaVpIM0mTZLkBRFJwroel6ik+n6viBsGobhpG0YeN4caKQmDZsb2XE8bifFlsaMmASJvb4PI+SFMUUW9HJgSpbUa6wl8NH/NgzD9pQPbYQKbAfMAb62I8yxERwXgUOk7Bsm85I3IMUAMAIRpEcAwKCLOiLlUR1CkGcdT5ZwhU5B5EbYBuH67DQMa+XkRrTCcQbee0vmlJSpk2tgUl+DWZQHLEMUAERzWwC3UOdiTpSl2iKZarxZDk8U2cUR1OdY8SlDFjhsL893Cg9lRrmNBUoVNPWebN83HktPjcPlpAIruwZuD5Pg7b0e2hAdkTRN9gFWH9Z0FudABCFDDRMaNnAwd3g7JT2Ji9lnvQltkk6T5P5tggPAyzlJgw9dQNAgBgBWkeAAJzytjIj4PawBSc6V03Uj1ArV4a2rA52CRRaSAK9roKq+rmuI0rKNgGjJyG8ba5g+gtyGKQ05hjNBKItwF6+NxSBIiNtHzGy0MXj+LyDZgbuDHC2FgAenyMlGvzAJQXX+5eIVx2gADEox1QKdQitwsMRhOYBvAw4GytXtfgQA0rYZz4HkAAealCGyUY54H2CYCZa7jZNXtw9bi1K7r+ulCKABitNsGcyr2PYGeysPprzAcAD6iQiwpgTl5XwCN3XpYXy3bcd930yCH32AD3nI+BGP0MTzNU/UNrdsO7uWIi9l6r3Xpvbeu9sAH2qOgAuw0zjF35KQdASQgA===).
And for mono (in GNU/Linux):
``mono --aot zerocost.exe``
``objdump -d -M intel zerocost.exe.so > zerocost.exe.so.dump``
``cat zerocost.exe.so.dump #Looking for <App_Main>``
