    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace WeaponInfoTemplateGenerator
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (args.Length < 0)
                    return;
    
                if (!args.All(i => i.EndsWith(".meta")) && !args.All(i => i.EndsWith(".xml")))
                    return;
    
                try
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        var arg = args[i];
                        Console.WriteLine("Enter a string value:");
                        var userInput = Console.ReadLine();
    
                        XDocument doc = XDocument.Load(arg);
                        doc.RemoveSimilarNodes(userInput, "Entry", "SlotNavigateOrder", "Item", "WeaponSlots", "Item");
                        doc.RemoveSimilarNodes(userInput, "Entry", "SlotBestOrder", "WeaponSlots", "Item");
                        doc.ClearNode("TintSpecValues");
                        doc.ClearNode("FiringPatternAliases");
                        doc.ClearNode("UpperBodyFixupExpressionData");
                        doc.ClearNode("AimingInfos");
                        doc.RemoveSimilarNodes(userInput, "Name", "Infos", "Item", "Infos", "Item");
                        doc.ClearNode("VehicleWeaponInfos");
                        doc.Save(arg + ".new.xml");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                    Console.ReadLine();
                }
    
                Console.WriteLine("Press [Enter] to exit...");
                Console.ReadLine();
            }
        }
    }
---
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace WeaponInfoTemplateGenerator
    {
        public static class Util
        {
    
            public static void RemoveSimilarNodes(this XDocument doc, string targetStringValue, string targetDescendant, params string[] path)
            {
                // Go to the last node.
                IEnumerable<XElement> currentNode = null;
                for (int i = 0; i < path.Length; i++)
                {
                    string name = path[i];
                    if (currentNode == null)
                    {
                        currentNode = doc.Descendants(name);
                        continue;
                    }
    
                    currentNode = currentNode.Descendants(name);
                }
    
                // Check the target descendant, and get it's children.
                List<XElement> navOrders = currentNode.Where(x => !x.Descendants(targetDescendant).Where(y => ((string)y).Contains(targetStringValue)).Any()).ToList();
    
                // Remove the nodes.
                foreach (XElement node in navOrders)
                {
                    node.Remove();
                }
            }
    
            public static void ClearNode(this XDocument doc, string descendant)
            {
                List<XElement> desc = doc.Descendants(descendant).ToList();
                desc.DescendantNodes().Remove();
            }
        }
    }
