    public class SerialPortTests
    {
        //Your states are pretty obscure to me, I'm making those up.
        private enum States
        {
            State1,
            State2,
            State3
        }
    
        private States _state = States.State1;
        private SerialPort _port = new SerialPort(/*Enter your port's config here*/);
    
        public SerialPortTests()
        {
            _port.DataReceived += dataReceived;
            _port.Open();
        }
    
        private void dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var sendingPort = (SerialPort)sender;
            var data = sendingPort.ReadExisting(); //Careful, you may have more than 1 line in data.
            var dataLines = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in dataLines)
            {
                verifyState(line);
                processLine(line);
            }
        }
    
        private void verifyState(string line)
        {
            //Your states are pretty obscure, I'm just making things up here.
            if (line == "FEED" && _state != States.State1)
            {
                //Handle the error if you can, or just throw to learn more about the problem in the stack trace.
                throw new ApplicationException("received FEED while in state " + _state);
            }
        }
    
        private void processLine(string line)
        {
            if (line == "FEED")
            {
                //Don't use MessageBox unless you really have to. Change a label's text or something.
                Console.WriteLine("Feeds already being dispense!");
                _state = States.State2;
            }
        }  
    }
