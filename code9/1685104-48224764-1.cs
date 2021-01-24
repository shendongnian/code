    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication19
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XNamespace ns = doc.Root.GetDefaultNamespace();
                DataTable dt = new DataTable();
                dt.Columns.Add("FileId", typeof(string));
                dt.Columns.Add("FileCreateDateTime", typeof(DateTime));
                dt.Columns.Add("StateCd", typeof(string));
                dt.Columns.Add("CoverageYear", typeof(int));
                dt.Columns.Add("PayeeId", typeof(string));
                dt.Columns.Add("StateTPID", typeof(string));
                dt.Columns.Add("IssuerId", typeof(string));
                
                dt.Columns.Add("OriginalSBMIFileId", typeof(string));
                dt.Columns.Add("OriginalSBMIExtractDateTime", typeof(DateTime));
                dt.Columns.Add("CMSPolicyVersionDateTime", typeof(DateTime));
                dt.Columns.Add("QHPId", typeof(string));
                dt.Columns.Add("ExchangeAssignedPolicyId", typeof(string));
                dt.Columns.Add("ExchangeAssignedSubscriberId", typeof(string));
                dt.Columns.Add("PolicyStartDate", typeof(DateTime));
                dt.Columns.Add("PolicyEndDate", typeof(DateTime));
                dt.Columns.Add("EffectuationInd", typeof(string));
                dt.Columns.Add("InsuranceLineCode", typeof(string));
                dt.Columns.Add("ExchangeAssignedMemberId", typeof(string));
                dt.Columns.Add("SubscriberIndicator", typeof(string));
                dt.Columns.Add("MemberLastName", typeof(string));
                dt.Columns.Add("MemberFirstName", typeof(string));
                dt.Columns.Add("BirthDate", typeof(DateTime));
                dt.Columns.Add("SocialSecurityNumber", typeof(string));
                dt.Columns.Add("PostalCode", typeof(string));
                dt.Columns.Add("LanguageQualifierCode", typeof(string));
                dt.Columns.Add("LanguageCode", typeof(string));
                dt.Columns.Add("GenderCode", typeof(string));
                dt.Columns.Add("TobaccoUseCode", typeof(string));
                dt.Columns.Add("FinancialEffectiveStartDate", typeof(DateTime));
                dt.Columns.Add("FinancialEffectiveEndDate", typeof(DateTime));
                dt.Columns.Add("MonthlyTotalPremiumAmount", typeof(decimal));
                dt.Columns.Add("MonthlyTotalIndividualResponsibilityAmount", typeof(decimal));
                dt.Columns.Add("MonthlyAPTCAmount", typeof(decimal));
                dt.Columns.Add("MonthlyCSRAmount", typeof(decimal));
                dt.Columns.Add("CSRVariantId", typeof(string));
                dt.Columns.Add("RatingArea", typeof(string));
                XElement fileInfo = doc.Descendants(ns + "FileInformation").FirstOrDefault();
                string fileId = (string)fileInfo.Element(ns + "FileId");
                DateTime fileCreateDate = (DateTime)fileInfo.Element(ns + "FileCreateDateTime");
                string stateCd = (string)fileInfo.Element(ns + "StateCd");
                int coverageYear = (int)fileInfo.Element(ns + "CoverageYear");
                string payeeId = (string)fileInfo.Element(ns + "PayeeId");
                string stateID = (string)fileInfo.Element(ns + "StateTPID");
                string issueID = (string)fileInfo.Element(ns + "IssuerId");
                XElement policy = doc.Descendants(ns + "Policy").FirstOrDefault();
                string originalFileId = (string)policy.Element(ns + "OriginalSBMIFileId");
                DateTime originalExactDate = (DateTime)policy.Element(ns + "OriginalSBMIExtractDateTime");
                string policyVersion = (string)policy.Element(ns + "CMSPolicyVersionDateTime");
                string qhpId = (string)policy.Element(ns + "QHPId");
                string assignedPolicyId = (string)policy.Element(ns + "ExchangeAssignedPolicyId");
                string exchangeSubscriberId = (string)policy.Element(ns + "ExchangeAssignedSubscriberId");
                DateTime policyStartDate = (DateTime)policy.Element(ns + "PolicyStartDate");
                DateTime policyEndDate = (DateTime)policy.Element(ns + "PolicyEndDate");
                string effectuationInd = (string)policy.Element(ns + "EffectuationInd");
                string insuranceLineCode = (string)policy.Element(ns + "InsuranceLineCode");
                XElement financialInformation = policy.Element(ns + "FinancialInformation");
                DateTime financialEffectiveStartDate = (DateTime)financialInformation.Element(ns + "FinancialEffectiveStartDate");
                DateTime financialEffectiveEndDate = (DateTime)financialInformation.Element(ns + "FinancialEffectiveEndDate");
                decimal monthlyTotalPremiumAmount = (decimal)financialInformation.Element(ns + "MonthlyTotalPremiumAmount");
                decimal monthlyTotalIndividualResponsibilityAmount = (decimal)financialInformation.Element(ns + "MonthlyTotalIndividualResponsibilityAmount");
                decimal monthlyAPTCAmount = (decimal)financialInformation.Element(ns + "MonthlyAPTCAmount");
                decimal monthlyCSRAmount = (decimal)financialInformation.Element(ns + "MonthlyCSRAmount");
                string CSRVariantId = (string)financialInformation.Element(ns + "CSRVariantId");
                string ratingArea = (string)financialInformation.Element(ns + "RatingArea");
                List<XElement> memberInformations = policy.Elements(ns + "MemberInformation").ToList();
                foreach (XElement memberInformation in memberInformations)
                {
                    string exchangeAssignedMemberId = (string)memberInformation.Element(ns + "ExchangeAssignedMemberId");
                    string SubscriberIndicator = (string)memberInformation.Element(ns + "SubscriberIndicator");
                    string MemberLastName = (string)memberInformation.Element(ns + "MemberLastName");
                    string MemberFirstName = (string)memberInformation.Element(ns + "MemberFirstName");
                    DateTime BirthDate = (DateTime)memberInformation.Element(ns + "BirthDate");
                    string SocialSecurityNumber = (string)memberInformation.Element(ns + "SocialSecurityNumber");
                    string PostalCode = (string)memberInformation.Element(ns + "PostalCode");
                    string LanguageQualifierCode = (string)memberInformation.Element(ns + "LanguageQualifierCode");
                    string LanguageCode = (string)memberInformation.Element(ns + "LanguageCode");
                    string GenderCode = (string)memberInformation.Element(ns + "GenderCode");
                    string TobaccoUseCode = (string)memberInformation.Element(ns + "TobaccoUseCode");
                    DateTime MemberStartDate = (DateTime)memberInformation.Descendants(ns + "MemberStartDate").FirstOrDefault();
                    DateTime MemberEndDate = (DateTime)memberInformation.Descendants(ns + "MemberEndDate").FirstOrDefault();
                    DataRow newRow = dt.Rows.Add();
                    // sample of adding rows to table, need to complete
                    newRow["ratingArea"] = ratingArea;
                    newRow["ExchangeAssignedMemberId"] = exchangeAssignedMemberId;
                }
            }
        }
    }
