    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                var xml = @"<?xml version='1.0' encoding='utf-8'?>
    <evec_api version=""2.0"" method=""marketstat_xml"">
        <marketstat>
            <type id=""626"">
                <buy>
                    <volume>11</volume>
                    <avg>9345454.55</avg>
                    <max>11500000.00</max>
                    <min>7500000.00</min>
                    <stddev>1862495.34</stddev>
                    <median>7600000.00</median>
                    <percentile>11500000.00</percentile>
                </buy>
                <sell>
                    <volume>23</volume>
                    <avg>18749987.25</avg>
                    <max>18749987.25</max>
                    <min>18749987.25</min>
                    <stddev>0.00</stddev>
                    <median>18749987.25</median>
                    <percentile>18749987.25</percentile>
                </sell>
                <all>
                    <volume>34</volume>
                    <avg>15707344.32</avg>
                    <max>18749987.25</max>
                    <min>7500000.00</min>
                    <stddev>4573474.77</stddev>
                    <median>18749987.25</median>
                    <percentile>7500000.00</percentile>
                </all>
            </type>
        </marketstat>
    </evec_api>";
    
                var xdoc = XDocument.Parse(xml);
                var typeElement = xdoc.Element("evec_api").Element("marketstat").Element("type");
                var avgElements = typeElement.Elements().Select(e => e.Element("avg"));
    
                foreach (var avgElement in avgElements)
                    Console.WriteLine(avgElement.Value);
            }
        }
    }
