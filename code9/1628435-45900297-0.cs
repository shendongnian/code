    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TicketingSystem;
    using System.Windows.Forms;
    using static TicketingSystem.TicketingSystem;
    namespace TicketingSystem
    {
    class Price
    {
        TicketingSystem ticketingSystem = new TicketingSystem();
        public ComboBox serviceDesc = new ComboBox();
        public Label textBlock_Price = new Label(); 
        public float? PricePlacement()
        {
            if (ticketingSystem.serviceDesc.Text != "Multiple")
            {
                if (ticketingSystem.serviceDesc.Text == "Phone Repair")
                {
                    textBlock_Price.Text = "$20.00 + Parts";
                    return 20.00f;
                }
                if (ticketingSystem.serviceDesc.Text == "Virus Removal")
                {
                    textBlock_Price.Text = "$10.00";
                    return 10.00f;
                }
                if (ticketingSystem.serviceDesc.Text == "Hardware Repair/Installation")
                {
                    textBlock_Price.Text = "$10.00";
                    return 10.00f;
                }
                if (ticketingSystem.serviceDesc.Text == "Software Installation")
                {
                    textBlock_Price.Text = "$5.00";
                    return 5.00f;
                }
                textBlock_Price.Text = "$0.00";
                return 0f;
            }
            else if (serviceDesc.Text == "Multiple")
            {
                //TODO: Implement a function to check if an item on the itemList is checked or not
                textBlock_Price.Text = "$-.--";
                return null;
            }
            return 0f;
        }
    }
