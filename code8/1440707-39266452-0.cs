    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                DataTable dt = new DataTable();
                dt.Columns.Add("Channel", typeof(string));
                dt.Columns.Add("busunit", typeof(string));
                dt.Columns.Add("dept", typeof(string));
                dt.Columns.Add("role", typeof(string));
                foreach (XElement channel in doc.Descendants("Channel"))
                {
                    string channelName = (string)channel.Attribute("name");
                    List<XElement> busunits = channel.Elements("busunit").ToList();
                    if (busunits.Count == 0)
                    {
                        dt.Rows.Add(new object[] { channelName });
                    }
                    else
                    {
                        foreach (XElement busunit in busunits)
                        {
                            string busunitName = (string)busunit.Attribute("name");
                            List<XElement> depts = busunit.Elements("dept").ToList();
                            if (depts.Count == 0)
                            {
                                dt.Rows.Add(new object[] { channelName, busunitName });
                            }
                            else
                            {
                                foreach (XElement dept in depts)
                                {
                                    string deptName = (string)dept.Attribute("name");
                                    List<XElement> roles = dept.Elements("role").ToList();
                                    if (roles.Count == 0)
                                    {
                                        dt.Rows.Add(new object[] { channelName, busunitName, deptName });
                                    }
                                    else
                                    {
                                        foreach (XElement role in roles)
                                        {
                                            string roleName = (string)role.Attribute("name");
                                            dt.Rows.Add(new object[] { channelName, busunitName, deptName, roleName });
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                dt = dt.AsEnumerable()
                    .OrderBy(m => m.Field<string>("Channel"))
                    .ThenBy(n => n.Field<string>("busunit"))
                    .ThenBy(o => o.Field<string>("dept"))
                    .ThenBy(p => p.Field<string>("role"))
                    .CopyToDataTable();
                //remove duplicates
                for (int row = dt.Rows.Count - 2; row >= 0; row--)
                {
                    if ((dt.Rows[row].Field<object>("Channel") == dt.Rows[row + 1].Field<object>("Channel")) &&
                       (dt.Rows[row].Field<object>("busunit") == dt.Rows[row + 1].Field<object>("busunit")) &&
                       (dt.Rows[row].Field<object>("dept") == dt.Rows[row + 1].Field<object>("dept")) &&
                       (dt.Rows[row].Field<object>("role") == dt.Rows[row + 1].Field<object>("role")))
                    {
                        dt.Rows[row + 1].Delete();
                    }
                 }
                dt.AcceptChanges();
            }
        }
    }
