    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication49
        {
        class Program
        {
            static void Main(string[] args)
            {
                List<csvRow> unsortedRows = new List<csvRow>();
                const string filePath = @"Navigation.csv";
                StreamReader sr = new StreamReader(File.OpenRead(filePath));
                string data = sr.ReadLine();
                while (data != null)
                {
                    var dataSplit = data.Split(';');   
                    //We need to avoid parsing the first line. 
                    if (dataSplit[0] != "ID" )
                    {
                        csvRow lis = new csvRow(dataSplit);
                        unsortedRows.Add(lis);
                    }
                    // Break out of infinite loop
                    data = sr.ReadLine();
                }
                sr.Dispose();
                var roots = unsortedRows.Where(row => row.ParentId.HasValue == false).
                    OrderBy(root => root.MenuName).ToList();
                
                foreach (csvRow root in roots)
                {
                    root.addChildrenFrom(unsortedRows);
                }
                
                foreach (csvRow root in roots)
                {
                    foreach (string FamilyMember in root.FamilyTree)
                    {
                        Console.WriteLine(FamilyMember);
                    }
                }
                Console.Read();
            }
        }
        public partial class csvRow
        {
            // Your Data
            public int Id { get; private set; }
            public string MenuName { get; private set; }
            public int? ParentId { get; private set; }
            public bool isHidden { get; private set; }
            public string LinkURL { get; private set; }
            
            public csvRow(string[] arr)
            {
                Id = Int32.Parse(arr[0]);
                MenuName = arr[1];
                ParentId = ToNullableInt(arr[2]);
                isHidden = bool.Parse(arr[3]);
                LinkURL = arr[4];
            }
            private static int? ToNullableInt(string s)
            {
                int i;
                if (int.TryParse(s, out i))
                    return i;
                else
                    return null;
            }
            private List<csvRow> children = new List<csvRow>();
            public List<csvRow> ChildrenSorted
            {
                get
                {
                    return children.OrderBy(row => row.MenuName).ToList();
                }
            }
            public void addChildrenFrom(List<csvRow> unsortedRows)
            {
                this.children.AddRange(unsortedRows.Where(
                    row => row.ParentId.HasValue &&
                    row.ParentId == this.Id &&
                    !this.children.Any(child => child.Id == row.Id)));
                foreach (csvRow child in this.children)
                {
                    child.addChildrenFrom(unsortedRows);
                }
            }
            public List<string> FamilyTree
            {
                get
                {
                    List<string> myFamily = new List<string>();
                    myFamily.Add(this.MenuName);
                    foreach (csvRow child in this.ChildrenSorted)
                    {
                        foreach (string familyMember in child.FamilyTree)
                        {
                            myFamily.Add("\t" + familyMember);
                        }
                    }
                    return myFamily;
                }
            }
        }
    }
