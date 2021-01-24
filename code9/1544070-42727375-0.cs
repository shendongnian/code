    public class TicketStatusParameters
        {
           [Prompt("Please enter a ticket number {||}")]
           [Describe("Ticket Number")]
           [Template(TemplateUsage.NotUnderstood, "Please enter a valid ticket number. I did not understand \"{0}\"")]
           public int? TicketNumber { get; set; }
       }
