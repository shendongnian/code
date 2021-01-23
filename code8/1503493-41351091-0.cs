    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement countyRolls = (XElement)doc.FirstNode;
                XNamespace ns = countyRolls.GetDefaultNamespace();
                var results = countyRolls.Elements(ns + "Municipality").Select(x => new {
                    municipalityNumber = (string)x.Element(ns + "MunicipalityNumber"),
                    items = x.Elements(ns + "Item").Select(y => new {
                       recordNumber = (int)y.Element(ns + "RecordNumber"),
                       propertyInfo = y.Elements(ns + "PropertyInfo").Select(z => new {
                          localID1 = (string)z.Element(ns + "LocalID1"),
                          localID2 = (string)z.Element(ns + "LocalID2"),
                          zoning = (string)z.Element(ns + "Zoning"),
                          town = (string)z.Element(ns + "Town"),
                          range = (string)z.Element(ns + "Range"),
                          rangeDirection = (string)z.Element(ns + "RangeDirection"),
                          section = (string)z.Element(ns + "Section"),
                          quarter40 = (string)z.Element(ns + "Quarter40"),
                          quarter160 = (string)z.Element(ns + "Quarter160"),
                          legal = (string)z.Element(ns + "Legal"),
                          recordingDocuments = z.Elements(ns + "RecordingDocuments").Select(a => new {
                               book = (int)a.Element(ns + "Book"),
                               page = (int)a.Element(ns + "Page"),
                               documentNumber = (int)a.Element(ns + "DocumentNumber")
                          }).ToList()
                       }).FirstOrDefault(),
                       ownerAndAddressInfo = y.Elements(ns + "OwnerAndAddressInfo").Select(z => new { 
                           mailingAddress = z.Descendants(ns + "USAddress").Select(a => new {
                               addressLine1 = (string)a.Element(ns + "AddressLine1"),
                               city = (string)a.Element(ns + "City"),
                               state = (string)a.Element(ns + "State"),
                               zipCode = (string)a.Element(ns + "ZIPCode"),
                           }).FirstOrDefault(),
                           owners = z.Elements(ns + "Owner").Select(a => new {
                               firstName = (string)a.Descendants(ns + "FirstName").FirstOrDefault(),
                               lastName = (string)a.Descendants(ns + "LastName").FirstOrDefault(),
                               addressLine1 = (string)a.Descendants(ns + "AddressLine1").FirstOrDefault(),
                               city = (string)a.Descendants(ns + "City").FirstOrDefault(),
                               state = (string)a.Descendants(ns + "State").FirstOrDefault(),
                               zipCode = (string)a.Descendants(ns + "ZIPCode").FirstOrDefault(),
                           }).ToList(),
                           siteAddress = z.Elements(ns + "SiteAddress").Select(a => new {
                               addressLine1 = (string)a.Descendants(ns + "AddressLine1").FirstOrDefault(),
                               city = (string)a.Descendants(ns + "City").FirstOrDefault(),
                               state = (string)a.Descendants(ns + "State").FirstOrDefault(),
                               zipCode = (string)a.Descendants(ns + "ZIPCode").FirstOrDefault(),
                           }).FirstOrDefault()
                       }).FirstOrDefault(),
                       realProperty = y.Descendants(ns + "RealProperty").Select(z => new {
                           class4 = z.Elements(ns + "Class4").Select(a => new {
                              acres = (decimal)a.Element(ns + "Acres"),
                              landValue = (int)a.Element(ns + "LandValue"),
                              improvementsValue = (int)a.Element(ns + "ImprovementsValue")
                           }).FirstOrDefault(),
                           class5m = z.Elements(ns + "Class5M").Select(a => new {
                              acres = (decimal)a.Element(ns + "Acres"),
                              landValue = (int)a.Element(ns + "LandValue"),
                              improvementsValue = (int)a.Element(ns + "ImprovementsValue")
                           }).FirstOrDefault(),
                           classTotal = z.Elements(ns + "ClassTotal").Select(a => new {
                              acres = (decimal)a.Element(ns + "Acres"),
                              landValue = (int)a.Element(ns + "LandValue"),
                              improvementsValue = (int)a.Element(ns + "ImprovementsValue")
                           }).FirstOrDefault(),
                       }).FirstOrDefault(),
                       jurisdictionInfo = y.Elements(ns + "JurisdictionInfo").Select(z => new {
                           county = z.Elements(ns + "County").Select(a => new {
                               countName = (string)a.Element(ns + "CountyName"),
                               countRate = (string)a.Element(ns + "CountyRate"),
                               countTax = (string)a.Element(ns + "CountyTax")
                           }).FirstOrDefault(),
                           municipality = z.Elements(ns + "Municipality").Select(a => new {
                               muniName = (string)a.Element(ns + "MuniName"),
                               muniNumber = (string)a.Element(ns + "MuniNumber"),
                               municipalRate = (string)a.Element(ns + "MunicipalRate"),
                               municipalTax = (string)a.Element(ns + "MunicipalTax")
                           }).FirstOrDefault(),
                           school = z.Elements(ns + "School").Select(a => new {
                               code = (string)a.Element(ns + "Code"),
                               rate = (string)a.Element(ns + "Rate"),
                               tax = (string)a.Element(ns + "Tax")
                           }).FirstOrDefault(),
                           tech = z.Elements(ns + "Tech").Select(a => new {
                               code = (string)a.Element(ns + "Code"),
                               rate = (string)a.Element(ns + "Rate"),
                               tax = (string)a.Element(ns + "Tax")
                           }).FirstOrDefault()
                       }).FirstOrDefault(),
                       taxSummary = y.Elements(ns + "TaxSummary").Select(z => new {
                           landTaxableTotal = (int)z.Element(ns + "LandTaxableTotal"),
                           improvementsTaxableTotal = (int)z.Element(ns + "ImprovementsTaxableTotal"),
                           totalTaxableValue = (int)z.Element(ns + "TotalTaxableValue"),
                           estimatedFairMarketValue = (int)z.Element(ns + "EstimatedFairMarketValue"),
                           stateTax = (decimal)z.Element(ns + "StateTax"),
                           occupationalTax = (int)z.Element(ns + "OccupationalTax"),
                           forestTaxable = (int)z.Element(ns + "ForestTaxable"),
                           bORValue = (int)z.Element(ns + "BORValue"),
                           privateForestCropTax = (decimal)z.Element(ns + "PrivateForestCropTax"),
                           managedForestLawTax = (decimal)z.Element(ns + "ManagedForestLawTax"),
                           taxTotal = (decimal)z.Element(ns + "TaxTotal"),
                           schoolCredit = (decimal)z.Element(ns + "SchoolCredit"),
                           lotteryCredit = (decimal)z.Element(ns + "LotteryCredit"),
                           firstDollarCredit = (decimal)z.Element(ns + "FirstDollarCredit"),
                           specialAssessmentDesc = (string)z.Descendants(ns + "SpecialAssessmentDesc").FirstOrDefault(),
                           specialAssessmentCharge = (int)z.Descendants(ns + "SpecialAssessmentCharge").FirstOrDefault(),
                           delinquentUtilityCharges = (int)z.Element(ns + "DelinquentUtilityCharges"),
                           netTax= (decimal)z.Element(ns + "NetTax"),
                           payment = (decimal)z.Element(ns + "Payment"),
                           amountDue = (decimal)z.Element(ns + "AmountDue")
                       }).FirstOrDefault()
                    }).ToList(),
                    chargebacks = x.Element(ns + "Chargebacks").Descendants(ns + "Total").Select(y => y == null ? 0 : (int)y).FirstOrDefault()
                }).ToList();
            }
        }
    }
