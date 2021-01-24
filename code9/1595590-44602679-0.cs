    using System;
    using System.Collections.Generic;
    
    public sealed class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }
        public string Email { get; }
        
        public Person(string firstName, string lastName, int age, string email)
        {
            // TODO: Validation
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
        }
    }
    
    public class Test
    {
        private static Person CreatePersonFromUserInput()
        {
            Console.WriteLine("Enter the first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the age:");
            int age = RequestInt32();
            Console.WriteLine("Enter the email address:");
            string email = Console.ReadLine();
            return new Person(firstName, lastName, age, email);
        }        
        
        private static int RequestInt32()
        {
            string text = Console.ReadLine();
            int ret;
            while (!int.TryParse(text, out ret))
            {
                Console.WriteLine("Invalid value. Please try again.");
                text = Console.ReadLine();
            }
            return ret;
        }
    
        private static void Main()
        {
            Console.WriteLine("Enter the count of people you would like to store:");
            int count = RequestInt32();
            List<Person> people = new List<Person>();
            for (int i = 0; i < count; i++)
            {
                people.Add(CreatePersonFromUserInput());
            }
            // Just to show them...
            foreach (Person person in people)
            {
                Console.WriteLine(
                    $"First: {person.FirstName}; Last: {person.LastName}; Age: {person.Age}; Email: {person.Email}");
            }
        }
        
    }
