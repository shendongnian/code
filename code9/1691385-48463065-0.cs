    using Microsoft.Exchange.Management.TransportLogSearchTasks;
    .....
    foreach (PSObject obj in mailBoxes){
      MessageTrackingEvent mte = (MessageTrackingEvent) obj;
      stringBuilder.AppendLine(mte.MessageInfo);
    }
