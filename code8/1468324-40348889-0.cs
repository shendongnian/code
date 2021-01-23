    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Informe a data no formato aaaa-mm-dd");
    		DateTime dataInformada = DateTime.Parse(Console.ReadLine());
    		
    		Console.Write("Dia do ano: " + dataInformada.DayOfYear);
    	}
    }
