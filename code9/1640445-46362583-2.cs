    using System.Text;
    [...]
    var orderListBody = new StringBuilder();
    var eml = string.Empty;
    var sbj = string.Empty;
    foreach (DataRow Row in ds.Tables["SalesOrders"].Rows)
    {
      orderListBody.Append("Order Number " + Row["Sales Order"] + "</br>");
      orderListBody.Append("Part Number: " + Row["Part Number"] + "</br>");
      orderListBody.Append("Description: " + Row["Description"] + "</br>");
      orderListBody.Append("Customer Part Number: " + Row["Customer Part No"] + "</br>");
      orderListBody.Append("Customer Revision: " + Row["Customer Rev"] + "</br>");
      DateTime dte = DateTime.Now;
      orderListBody.Append("Expected Ship Date: " + dte.ToShortDateString() + "</br>");
      orderListBody.Append("Quantity: " + Row["Quantity"] + "</br>");
      orderListBody.Append("</br>"); //Adding extra line break between two orders.
      eml = Row["Email"];
      sbj = "Order Acknowledgement for your PO " + Row["Customer PO"] + "</br>";
    }
