            clear();
            coinRefundComplete.Visible = true;
            state = 0;
            //new line of code
            System.Windows.Forms.Application.DoEvents();
            System.Threading.Thread.Sleep(4000);
            clear();
            greeting.Visible = true;
            rate.Visible = true;
            refundTicket.Visible = true;
            currentTime.Visible = true;
