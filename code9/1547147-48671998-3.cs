    namespace GatewayTest
    {
        using System;
        using System.Text;
        using System.Threading;
        using System.Threading.Tasks;
        using DotNetty.Buffers;
        using Microsoft.Azure.Devices.ProtocolGateway.Identity;
        using Microsoft.Azure.Devices.ProtocolGateway.IotHubClient;
        using Microsoft.Azure.Devices.ProtocolGateway.Messaging;
    
        public class IoTHubConnection : IMessagingChannel<IMessage>
        {
            private readonly string iotHubHostName;
            private readonly Func<IDeviceIdentity, Task<IMessagingServiceClient>> deviceClientFactory;
            private readonly Func<string, Task> onMessage;
            private IMessagingServiceClient deviceClient;
            private IDeviceIdentity deviceIdentity;
    
            public IoTHubConnection(
                string iotHubHostName,
                Func<IDeviceIdentity, Task<IMessagingServiceClient>> deviceClientFactory,
    			Func<string, Task> onMessage)
            {
                this.iotHubHostName = iotHubHostName;
                this.deviceClientFactory = deviceClientFactory;
                this.onMessage = onMessage;
            }
    
            public event EventHandler CapabilitiesChanged;
    
            public async Task OpenAsync(string deviceId, string deviceKey)
            {
                this.deviceIdentity = this.GetDeviceIdentity(deviceId, deviceKey);
                if (this.deviceIdentity != UnauthenticatedDeviceIdentity.Instance)
                {
                    this.deviceClient = await this.deviceClientFactory(this.deviceIdentity);
                    this.deviceClient.BindMessagingChannel(this);
                }
            }
    
            public async Task CloseAsync()
            {
    			await this.deviceClient.DisposeAsync(null);
    			this.deviceClient = null;
            }
    
            public void Handle(IMessage message)
            {
    			var messageBody = message.Payload.ToString(Encoding.UTF8);
    
    			this.onMessage(messageBody);
    			
    			this.deviceClient.CompleteAsync(message.Id);
            }
    
            public Task SendMessage(string message)
            {
                var buffer = Unpooled.WrappedBuffer(Encoding.UTF8.GetBytes(message));
                var deviceMessage = this.deviceClient.CreateMessage($"devices/{this.deviceIdentity.Id}/messages/events", buffer);
                return this.deviceClient.SendAsync(deviceMessage);
            }
    
            protected virtual void OnCapabilitiesChanged(EventArgs e)
            {
                this.CapabilitiesChanged?.Invoke(this, e);
            }
    
            private IDeviceIdentity GetDeviceIdentity(string userName, string deviceKey)
            {
                IotHubDeviceIdentity ideviceIdentity;
                if (!IotHubDeviceIdentity.TryParse($"{this.iotHubHostName}/{userName}", out ideviceIdentity))
                {
                    return UnauthenticatedDeviceIdentity.Instance;
                }
    
                ideviceIdentity.WithDeviceKey(deviceKey);
                return ideviceIdentity;
            }
        }
    }
