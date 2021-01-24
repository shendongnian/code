    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("TxnID",typeof(string));
                dt.Columns.Add("TimeCreated",typeof(DateTime));
                dt.Columns.Add("TimeModified",typeof(DateTime));
                dt.Columns.Add("EditSequence",typeof(long));
                dt.Columns.Add("TxnNumber",typeof(int));
                dt.Columns.Add("VendorListID",typeof(string));
                dt.Columns.Add("VendorFullName",typeof(string));
                dt.Columns.Add("APAccountListID", typeof(string));
                dt.Columns.Add("APAccountFullName", typeof(string));
                dt.Columns.Add("TxnDate", typeof(DateTime));
                dt.Columns.Add("DueDate",typeof(DateTime));
                dt.Columns.Add("AmountDue",typeof(decimal));
                dt.Columns.Add("TermsListID",typeof(string));
                dt.Columns.Add("TermsFullName",typeof(string));
                dt.Columns.Add("IsPaid",typeof(Boolean));
                dt.Columns.Add("LinkedTxnID", typeof(string));
                dt.Columns.Add("LinkedTxnType", typeof(string));
                dt.Columns.Add("LinkedTxnDate", typeof(DateTime));
                dt.Columns.Add("LinkedRefNumber", typeof(int));
                dt.Columns["LinkedRefNumber"].AllowDBNull = true;
                dt.Columns.Add("LinkType",typeof(string));
                dt.Columns.Add("Amount",typeof(decimal));
                dt.Columns.Add("OpenAmount", typeof(decimal));
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement billRet in doc.Descendants("BillRet"))
                {
                    string txnID = (string)billRet.Element("TxnID");
                    DateTime timeCreated = (DateTime)billRet.Element("TimeCreated");
                    DateTime timeModified = (DateTime)billRet.Element("TimeModified");
                    long editSequence = (long)billRet.Element("EditSequence");
                    int TxnNumber = (int)billRet.Element("TxnNumber");
                    string vendorListID = (string)billRet.Element("VendorRef").Element("ListID");
                    string vendorFullName = (string)billRet.Element("VendorRef").Element("FullName");
                    string apAccountListID = (string)billRet.Element("APAccountRef").Element("ListID");
                    string apAccountFullName = (string)billRet.Element("APAccountRef").Element("FullName");
                    DateTime txnDate = (DateTime)billRet.Element("TxnDate");
                    DateTime dueDate = (DateTime)billRet.Element("DueDate");
                    string termsListID = (string)billRet.Element("TermsRef").Element("ListID");
                    string termsFullName = (string)billRet.Element("TermsRef").Element("FullName");
                    decimal amountDue = (decimal)billRet.Element("AmountDue");
                    decimal openAmount = (decimal)billRet.Element("OpenAmount");
                    Boolean isPaid = (Boolean)billRet.Element("IsPaid");
                    
                    foreach (XElement linkedTxn in billRet.Elements("LinkedTxn"))
                    {
                        DataRow newRow = dt.Rows.Add();
                        newRow["TxnID"] = txnID;
                        newRow["TimeCreated"] = timeCreated;
                        newRow["TimeModified"] = timeModified;
                        newRow["EditSequence"] = editSequence;
                        newRow["TxnNumber"] = TxnNumber;
                        newRow["VendorListID"] = vendorListID;
                        newRow["VendorFullName"] = vendorFullName;
                        newRow["APAccountListID"] = apAccountListID;
                        newRow["APAccountFullName"] = apAccountFullName;
                        newRow["TxnDate"] = txnDate;
                        newRow["DueDate"] = dueDate;
                        newRow["TermsListID"] = termsListID ;
                        newRow["TermsFullName"] = termsFullName;
                        newRow["AmountDue"] = amountDue;
                        newRow["OpenAmount"] = openAmount;
                        newRow["IsPaid"] = isPaid;
                        newRow["LinkedTxnID"] = (string)linkedTxn.Element("TxnID");
                        newRow["LinkedTxnType"] = (string)linkedTxn.Element("TxnType");
                        newRow["LinkedTxnDate"] = (DateTime)linkedTxn.Element("TxnDate");
                        if(linkedTxn.Element("RefNumber") != null)
                           newRow["LinkedRefNumber"] = (int)linkedTxn.Element("RefNumber");
                        newRow["LinkType"] = (string)linkedTxn.Element("LinkType");
                        newRow["Amount"] = (decimal)linkedTxn.Element("Amount");
                    }
                }
            }
        }
    }
