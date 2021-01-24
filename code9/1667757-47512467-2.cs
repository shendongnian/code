using System;
using System.Collections.Generic;
using System.Linq;
namespace ClassTest
{
&#9;public class Program
&#9;{
&#9;&#9;public static void Main(string[] args)
&#9;&#9;{
&#9;&#9;&#9;//Create a list to store people
&#9;&#9;&#9;ICollection&lt;Person&gt; people = new List&lt;Person&gt;();
&#9;&#9;&#9;//Add some people. Note that this is type-safe
&#9;&#9;&#9;people.Add(new Person(){Name = "John", Age = 23});
&#9;&#9;&#9;people.Add(new Person(){Name = "Doe", Age = 12});
&#9;&#9;&#9;people.Add(new Person(){Name = "Maria", Age = 41});
&#9;&#9;&#9;people.Add(new Person(){Name = "John", Age = 55}); //&lt;-- You can indeed have two people with the same name
&#9;&#9;&#9;//Create queries to ensure correct sorting
&#9;&#9;&#9;var peopleByName =&#9;from p in people
&#9;&#9;&#9;&#9;&#9;&#9;orderby p.Name
&#9;&#9;&#9;&#9;&#9;&#9;select p;
&#9;&#9;&#9;var peopleByAge =&#9;from p in people
&#9;&#9;&#9;&#9;&#9;&#9;orderby p.Age
&#9;&#9;&#9;&#9;&#9;&#9;select p;
&#9;&#9;&#9;//Execute the query and print results
&#9;&#9;&#9;foreach(var person in peopleByAge)
&#9;&#9;&#9;{
&#9;&#9;&#9;&#9;Console.WriteLine("Hello, my name is {0} and I am {1} years old", person.Name, person.Age);
&#9;&#9;&#9;}
&#9;&#9;}
&#9;}
&#9;public class Person
&#9;{
&#9;&#9;public string Name {get; set;}
&#9;&#9;public int Age {get; set;}
&#9;}
}
