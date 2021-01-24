    using System;
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.Diagnostics.Runtime;
    
    namespace ClrMdTest
    {
        class Program
        {
            static void Main(string[] args)
            {    
                var live = DataTarget.AttachToProcess(
                    Process.GetProcessesByName("clrmdexampletarget")[0].Id,
                    1000, AttachFlag.Passive);
                var liveClrVersion = live.ClrVersions[0];
                var liveRuntime = liveClrVersion.CreateRuntime();
                var addresses = liveRuntime.Heap.EnumerateObjectAddresses();
    
                // The where clause does some consistency check for live debugging
                // when the GC might cause the heap to be in an inconsistent state.
                var singleObjects = from obj in addresses
                    let type = liveRuntime.Heap.GetObjectType(obj)
                    where
                        type != null && !type.IsFree && !string.IsNullOrEmpty(type.Name) &&
                        type.Name.StartsWith("SomeInterestingNamespace")
                    select new { Address = obj, Type = type};
    
                foreach (var singleObject in singleObjects)
                {
                    foreach (var field in singleObject.Type.Fields)
                    {
                        Console.WriteLine(field.Name + " =");
                        Console.WriteLine("   " + field.GetValue(singleObject.Address));
                    }
                }
    
                Console.ReadLine();
            }
        }
    }
