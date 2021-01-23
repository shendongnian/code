        private void uicmdLocate_Click(object sender, EventArgs e)
        {
            OpenFileDialog myFile = new OpenFileDialog();
            myFile.Title = "Locate XML File";
            myFile.Filter = "XML Files|*.xml";
            if (myFile.ShowDialog() == DialogResult.OK)
            {
                this.uitxtXMLFile.Text = myFile.FileName;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.uitxtXMLFile.Text == "")
                {
                    throw new Exception("You must select an XML file to convert!");
                }
                string sDelimeter = "";
                string sExtension = "";
                switch (uicmbDelimiter.Text)
                {
                    case "TAB":
                        sDelimeter = "\t";
                        sExtension = ".txt";
                        break;
                    case "PIPE":
                        sDelimeter = "|";
                        sExtension = ".txt";
                        break;
                    case "COMMA":
                        sDelimeter = ",";
                        sExtension = ".csv";
                        break;
                    default:
                        sDelimeter = "\t";
                        sExtension = ".txt";
                        break;
                }
                StreamWriter csv = new StreamWriter(this.uitxtXMLFile.Text.Replace(".xml",sExtension));
                string csvstring = "";
                XDocument doc = XDocument.Load(this.uitxtXMLFile.Text);
                XElement countyRolls = (XElement)doc.FirstNode;
                XNamespace ns = countyRolls.GetDefaultNamespace();
                var results = countyRolls.Elements(ns + "Municipality").Select(x => new {
                    municipalityNumber = (string)x.Element(ns + "MunicipalityNumber"),
                    items = x.Elements(ns + "Item").Select(y => new {
                        recordNumber = (int)y.Element(ns + "RecordNumber"),
                        propertyInfo = y.Elements(ns + "PropertyInfo").Select(z => new {
                            localID1 = (string)z.Element(ns + "LocalID1"),
                            localID2 = (string)z.Element(ns + "LocalID2"),
                            zoning = z.Elements(ns + "Zoning").Select(a => (string)a).ToArray(),
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
                                businessNameLine1 = (string)a.Descendants(ns + "BusinessNameLine1").FirstOrDefault(),
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
                        taxSummary = y.Elements(ns + "TaxSummary").Select(z => new
                        {
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
                            specialAssessmentCharge = (decimal)z.Descendants(ns + "SpecialAssessmentCharge").FirstOrDefault(),
                            delinquentUtilityCharges = (decimal)z.Element(ns + "DelinquentUtilityCharges"),
                            netTax = (decimal)z.Element(ns + "NetTax"),
                            payment = (decimal)z.Element(ns + "Payment"),
                            amountDue = (decimal)z.Element(ns + "AmountDue"),
                            priorYearChargebacks = (decimal)z.Descendants(ns + "Total").FirstOrDefault(),
                            stateAssessedTelco = (decimal)z.Element(ns + "StateAssessedTelco")
                        }).FirstOrDefault()
                    }).ToList(),
                    chargebacks = x.Element(ns + "Chargebacks").Descendants(ns + "Total").Select(y => y == null ? 0 : (int)y).FirstOrDefault()
                }).ToList();
                this.progressBar1.Maximum = results[0].items.Count;
                this.progressBar1.Value = 0;
                this.progressBar1.Step = 1;
                csvstring += "recordNumber" + sDelimeter;
                csvstring += "localID1" + sDelimeter;
                csvstring += "localID2" + sDelimeter;
                csvstring += "legal" + sDelimeter;
                csvstring += "addressLine1" + sDelimeter;
                csvstring += "city" + sDelimeter;
                csvstring += "state" + sDelimeter;
                csvstring += "zipCode" + sDelimeter;
                csvstring += "owner" + sDelimeter;
                csvstring += "NameSeq" + sDelimeter;
                csvstring += "BusinessName" + sDelimeter;
                csvstring += "siteaddressLine1" + sDelimeter;
                csvstring += "sitecity" + sDelimeter;
                csvstring += "sitestate" + sDelimeter;
                csvstring += "sitezipCode" + sDelimeter;
                csvstring += "acres" + sDelimeter;
                csvstring += "landValue" + sDelimeter;
                csvstring += "improvementsValue" + sDelimeter;
                csvstring += "landTaxableTotal" + sDelimeter;
                csvstring += "improvementsTaxableTotal" + sDelimeter;
                csvstring += "estimatedFairMarketValue" + sDelimeter;
                csvstring += "stateTax" + sDelimeter;
                csvstring += "occupationalTax" + sDelimeter;
                csvstring += "forestTaxable" + sDelimeter;
                csvstring += "bORValue" + sDelimeter;
                csvstring += "privateForestCropTax" + sDelimeter;
                csvstring += "managedForestLawTax" + sDelimeter;
                csvstring += "taxTotal" + sDelimeter;
                csvstring += "schoolCredit" + sDelimeter;
                csvstring += "lotteryCredit" + sDelimeter;
                csvstring += "firstDollarCredit" + sDelimeter;
                csvstring += "specialAssessmentDesc" + sDelimeter;
                csvstring += "specialAssessmentCharge" + sDelimeter;
                csvstring += "delinquentUtilityCharges" + sDelimeter;
                csvstring += "netTax" + sDelimeter;
                csvstring += "payment" + sDelimeter;
                csvstring += "amountDue" + sDelimeter;
                csvstring += "priorYearChargebacks" + sDelimeter;
                csvstring += "stateAssessedTelco" + sDelimeter;
                csv.WriteLine(csvstring);
                csvstring = "";
                for (int i = 0; i < results[0].items.Count; i++)
                {
                    csvstring += results[0].items[i].recordNumber + sDelimeter;
                    // Write Property Info
                    csvstring += results[0].items[i].propertyInfo.localID1 + sDelimeter;
                    csvstring += results[0].items[i].propertyInfo.localID2 + sDelimeter;
                    csvstring += results[0].items[i].propertyInfo.legal + sDelimeter;
                    foreach (string element in results[0].items[i].propertyInfo.zoning)
                    {
                        csvstring += element;
                    }
                    csvstring += "\t";
                    // Write Owner Info
                    if (results[0].items[i].ownerAndAddressInfo.mailingAddress == null)
                    {
                        csvstring += "\t\t\t\t";
                    }
                    else
                    {
                        csvstring += results[0].items[i].ownerAndAddressInfo.mailingAddress.addressLine1 + sDelimeter;
                        csvstring += results[0].items[i].ownerAndAddressInfo.mailingAddress.city + sDelimeter;
                        csvstring += results[0].items[i].ownerAndAddressInfo.mailingAddress.state + sDelimeter;
                        csvstring += results[0].items[i].ownerAndAddressInfo.mailingAddress.zipCode + sDelimeter;
                    }
                    for (int io = 0; io < results[0].items[i].ownerAndAddressInfo.owners.Count; io++)
                    {
                        csvstring += results[0].items[i].ownerAndAddressInfo.owners[io].firstName + " ";
                        csvstring += results[0].items[i].ownerAndAddressInfo.owners[io].lastName + " ";
                    }
                    csvstring += sDelimeter;
                    csvstring += results[0].items[i].ownerAndAddressInfo.owners[0].lastName + " " + results[0].items[i].ownerAndAddressInfo.owners[0].firstName + sDelimeter;
                    csvstring += results[0].items[i].ownerAndAddressInfo.owners[0].businessNameLine1 + sDelimeter;
                    // Site Address
                    if (results[0].items[i].ownerAndAddressInfo.siteAddress == null)
                    {
                        csvstring += "\t\t\t\t";
                    }
                    else
                    {
                        csvstring += results[0].items[i].ownerAndAddressInfo.siteAddress.addressLine1 + sDelimeter;
                        csvstring += results[0].items[i].ownerAndAddressInfo.siteAddress.city + sDelimeter;
                        csvstring += results[0].items[i].ownerAndAddressInfo.siteAddress.state + sDelimeter;
                        csvstring += results[0].items[i].ownerAndAddressInfo.siteAddress.zipCode + sDelimeter;
                    }
                    // Valuation Information
                    csvstring += results[0].items[i].realProperty.classTotal.acres + sDelimeter;
                    csvstring += results[0].items[i].realProperty.classTotal.landValue + sDelimeter;
                    csvstring += results[0].items[i].realProperty.classTotal.improvementsValue + sDelimeter;
                    // Tax Summary Information
                    csvstring += results[0].items[i].taxSummary.landTaxableTotal + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.improvementsTaxableTotal + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.estimatedFairMarketValue + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.stateTax + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.occupationalTax + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.forestTaxable + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.bORValue + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.privateForestCropTax + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.managedForestLawTax + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.taxTotal + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.schoolCredit + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.lotteryCredit + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.firstDollarCredit + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.specialAssessmentDesc + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.specialAssessmentCharge + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.delinquentUtilityCharges + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.netTax + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.payment + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.amountDue + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.priorYearChargebacks + sDelimeter;
                    csvstring += results[0].items[i].taxSummary.stateAssessedTelco + sDelimeter;
                    csv.WriteLine(csvstring);
                    csvstring = "";
                    this.progressBar1.PerformStep();
                    Application.DoEvents();
                }
                csv.Close();
                MessageBox.Show("Complete!", "Done Processing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.progressBar1.Value = 0;
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Alert",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
