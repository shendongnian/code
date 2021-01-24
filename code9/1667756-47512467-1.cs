using System;
using System.Collections.Generic;
using System.Linq;
namespace DictionaryTest
{
&#9;public class Program
&#9;{
&#9;&#9;public static void Main(string[] args)
&#9;&#9;{
&#9;&#9;&#9;//Create a dictionary to store people
&#9;&#9;&#9;Dictionary&lt;string, int&gt; people = new Dictionary&lt;string, int&gt;();
&#9;&#9;&#9;//Add some people. Note that this is type-safe
&#9;&#9;&#9;people.Add("John", 23);
&#9;&#9;&#9;people.Add("Doe", 12);
&#9;&#9;&#9;people.Add("Maria", 41);
&#9;&#9;&#9;//people.Add("John", 55); // &lt;-- This will fail because there is already a John
&#9;&#9;&#9;//Create queries to ensure correct sorting
&#9;&#9;&#9;var peopleByName =&#9;from p in people
&#9;&#9;&#9;&#9;&#9;&#9;orderby p.Key //Our name is the key, the age is the value
&#9;&#9;&#9;&#9;&#9;&#9;select new {Name = p.Key, Age = p.Value};
&#9;&#9;&#9;var peopleByAge =&#9;from p in people
&#9;&#9;&#9;&#9;&#9;&#9;orderby p.Value //orderby p.Value descending //Use this instead if you want to sort oldest to youngest
&#9;&#9;&#9;&#9;&#9;&#9;select new {Name = p.Key, Age = p.Value};
&#9;&#9;&#9;//Execute the query and print results
&#9;&#9;&#9;foreach(var person in peopleByAge)
&#9;&#9;&#9;{
&#9;&#9;&#9;&#9;Console.WriteLine("Hello, my name is {0} and I am {1} years old", person.Name, person.Age);
&#9;&#9;&#9;}
&#9;&#9;}
&#9;}
}
