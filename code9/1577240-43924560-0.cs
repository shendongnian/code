    Debug.Log(order.order.orderStatusCode)
    if (order.order.orderStatusCode == "CANC")
       {
        cancelada.Enabled = true;
        gendada.Enabled = false;
        aberta.Enabled = false;
       }
    else if (order.order.orderStatusCode == "ABRT")
       {
        cancelada.Enabled = false;
        agendada.Enabled = false;
        aberta.Enabled = true;
        }
    else if (order.order.orderStatusCode == "AGEN")
        {
         cancelada.Enabled = false;
         agendada.Enabled = true;
         aberta.Enabled = false;
        }
