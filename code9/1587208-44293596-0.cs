    using System.Collections.Generic;
    using System;
    using System.Linq;
					
    public enum PatientPriority { Magenta = 0, Red = 1, Yellow = 2, Green = 3 }; 
    public class Utente
    {
	    public int Id{get; set;}
    	public string Name{get; set;}
	    public int Key{get; set;}
    	public string Email{get; set;}
	    public PatientPriority Priority{get; set;}
	
    	public Utente(int id, string name, int key, string email, PatientPriority priority)
	    {
	        Id = id;
		    Name = name;
    		Key = key;
    		Email = email;
    		Priority = priority;
    	}
	
    }
    public class Test
    {
	
    	public static void Main()
    {
	    	var ListaUtente = new List<Utente>(); 
		    ListaUtente.Add(new Utente(100001, "Pedro", 914754123, "pedro@gmail.com", PatientPriority.Yellow));
            ListaUtente.Add(new Utente(100002, "Lucas", 974123214, "lucas91@gmail.com", PatientPriority.Green));
            ListaUtente.Add(new Utente(100003, "Rodrigo", 941201456, "rodrigo00@gmail.com", PatientPriority.Yellow));
            ListaUtente.Add(new Utente(100004, "Gaspar", 987453210, "gaspar@gmail.com", PatientPriority.Red));
            ListaUtente.Add(new Utente(100005, "Roberto", 974120219, "roberto@gmail.com", PatientPriority.Magenta));
            ListaUtente.Add(new Utente(100006, "Eduardo", 974120219, "edu@gmail.com", PatientPriority.Red));
            ListaUtente.Add(new Utente(100007, "Ismael", 974120219, "Isma@gmail.com", PatientPriority.Green));
            ListaUtente.Add(new Utente(100008, "Paulo", 974120219, "Paulo90@gmail.com", PatientPriority.Yellow));
		
		    Console.WriteLine("Unsorted:");
    		foreach (var u in ListaUtente)
    		{
    			Console.WriteLine("id: " + u.Id + " Priority: " + u.Priority);
    		}
		
	    	Console.WriteLine("Sorted: ");
		    foreach(var su in ListaUtente.OrderBy(u => u.Priority).Take(6).ToList())
    		{
	    		Console.WriteLine("id: " + su.Id + " Priority: " + su.Priority);
		    }
	
    }
    }
