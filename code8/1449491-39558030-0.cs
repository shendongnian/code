    using System;
	using System.IO.Ports;
	using System.Threading;
	namespace SerialPortProgram
	{
		public class PortChat
		{
			static bool _continue = true;
			static SerialPort port = new SerialPort("COM1", 115200, Parity.None, 8, StopBits.One);
			public static void Main()
			{
				port.Handshake = Handshake.None;
				string message;
				StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
				port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
				port.Open();
				port.WriteLine("ATI");
				Console.WriteLine("Type QUIT to exit");
				while (_continue)
				{
					message = Console.ReadLine();
					if (stringComparer.Equals("quit", message))
					{
						_continue = false;
					}
					else
					{
						port.WriteLine(message);
					}
				}
				port.Close();
				port.Dispose();
			}
			private static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
			{
				// Show all the incoming data in the port's buffer
				Console.WriteLine(port.ReadExisting());
			}
		}
	}
