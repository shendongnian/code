    using System;
    using System.Collections.Generic;
    using RazorEngine;
    
    namespace MyApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var template = @"
    @using System.Collections.Generic;
    @using MyApp;
    @model IEnumerable<Customer>
    
    @foreach (var item in Model)
    {
        <tr>
            <td>
                @item.Name
            </td>
        </tr>
    }
    ";
    
                var result = Razor.Parse(template, new List<Customer>
                            { new Customer { Name = "Hello World" } });
                Console.WriteLine(result);
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    
        public class Customer
        {
            public string Name { get; set; }
        }
    }
