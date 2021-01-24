    using System;
    using System.IO;
    using EllieMae.Encompass.Client;
    using EllieMae.Encompass.BusinessObjects;
    using EllieMae.Encompass.Query;
    using EllieMae.Encompass.Collections;
    using EllieMae.Encompass.BusinessObjects.Loans;
    
    class LoanReader
    {
       public static void Main()
       {
          // Open the session to the remote server
          Session session = new Session();
          session.Start("myserver", "mary", "maryspwd");
    
          // Build the query criterion for all loans that were opened this year
          DateFieldCriterion dateCri = new DateFieldCriterion();
          dateCri.FieldName = "Loan.DateFileOpened";
          dateCri.Value = DateTime.Now;
          dateCri.Precision = DateFieldMatchPrecision.Year;
    
          // Perform the query to get the IDs of the loans
          LoanIdentityList ids = session.Loans.Query(dateCri);
    
          // Create a list of the specific fields we want to print from each loan.
          // In this case, we'll select the Loan Amount and Interest Rate.
          StringList fieldIds = new StringList();
          fieldIds.Add("2");          // Loan Amount
          fieldIds.Add("3");          // Rate
          // For each loan, select the desired fields
          foreach (LoanIdentity id in ids)
          {
             // Select the field values for the current loan
             StringList fieldValues = session.Loans.SelectFields(id.Guid, fieldIds);
    
             // Print out the returned values
             Console.WriteLine("Fields for loan " + id.ToString());
             Console.WriteLine("Amount:  " + fieldValues[0]);
             Console.WriteLine("Rate:    " + fieldValues[1]);
          }
    
          // End the session to gracefully disconnect from the server
          session.End();
       }
    }
