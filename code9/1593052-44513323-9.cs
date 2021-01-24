    using System;
    using static System.Console;
    
    namespace DynamicObjectGetterOverride {
        class Program {
            static void Main(string[] args) {
                dynamic testObject = new LoggedPropertyAccess();
                DateTime dob = testObject.DOB;
                string firstname = testObject.FirstName;
                string lastname = testObject.LastName;
    
                dynamic address = testObject.Address;
                address.House = "123";
                address.Street = "AnyStreet";
                address.City = "Anytown";
                address.State = "ST";
                address.Country = "USA";
    
                WriteLine("----- Writes the returned values from reading the properties");
                WriteLine(new { firstname, lastname, dob });
                WriteLine();
    
                WriteLine("----- Writes the actual values of each property");
                foreach (var kvp in testObject.__Properties) {
                    WriteLine($"{kvp.Key} = {kvp.Value}");
                }
                WriteLine();
    
                WriteLine("----- Writes the actual values of a nested object");
                foreach (var kvp in testObject.Address.__Properties) {
                    WriteLine($"{kvp.Key} = {kvp.Value}");
                }
                WriteLine();
    
                WriteLine("----- Writes the names of the accessed properties");
                foreach (var propertyName in testObject.__AccessedProperties) {
                    WriteLine(propertyName);
                }
                ReadKey();
            }
        }
    }
