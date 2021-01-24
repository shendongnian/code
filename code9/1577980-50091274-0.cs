    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using TeleSharp.TL;
    using TLSharp.Core;
    
    
    
    
    namespace t
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
    
            TelegramClient client;
            int api_id = your api_id ;
            string api_hash = "your api_hash ";
            string hash;
    
    
            public MainWindow()
            {
                InitializeComponent();
                TLSharp.Core.FileSessionStore store = new TLSharp.Core.FileSessionStore();
                client = new TelegramClient(api_id, api_hash, store, "session");
    
            }
    
            private async void button_Click(object sender, RoutedEventArgs e)
            {
                //if your app is not autenticated by telegram this code will send  request to add a new device then telegram will sent you a Autenticatin code
                await client.ConnectAsync();
                hash = await client.SendCodeRequestAsync("your Number in global format example : 98916*******");
    
            }
    
            private async void button1_Click(object sender, RoutedEventArgs e)
            {
                //if your app is not autenticated by telegram and you have sent request to telegram, this code will add new device using autenticatin code that telegram sent to you
                var code = txtAutCode.Text;  // this is a TextBox that you must insert the code that Telegram sent to you
                var user = await client.MakeAuthAsync("your Number in global format example : 98916*******", hash, code);
            }
    
            private async void button2_Click(object sender, RoutedEventArgs e)
            {
    
                await client.ConnectAsync();       
    
                // Here is the code that will add a new contact and send a test message
                TeleSharp.TL.Contacts.TLRequestImportContacts requestImportContacts = new TeleSharp.TL.Contacts.TLRequestImportContacts();
                requestImportContacts.Contacts = new TLVector<TLInputPhoneContact>();
                requestImportContacts.Contacts.Add(new TLInputPhoneContact()
                {
                    Phone = "new Number in global format example : 98916*******",
                    FirstName = "new Number's FirstName",
                    LastName = "new Number's LastName"
                });
                var o = await client.SendRequestAsync<TeleSharp.TL.Contacts.TLImportedContacts>((TLMethod)requestImportContacts);
                var NewUserId = (o.Users.First() as TLUser).Id;
                var d = await client.SendMessageAsync(new TLInputPeerUser() { UserId = NewUserId }, "test message text");
    
    
    
                //find recipient in contacts and send a message to it
                var result = await client.GetContactsAsync();           
                var user = result.Users
                    .Where(x => x.GetType() == typeof(TLUser))
                    .Cast<TLUser>()
                    .FirstOrDefault(x => x.Phone == "recipient Number in global format example : 98916*******");
                MessageBox.Show((user.LastName).ToString());
    
                //send message
                await client.SendMessageAsync(new TLInputPeerUser() { UserId = user.Id }, "hi test message");
            }
        }
    }
    <Window x:Class="t.MainWindow"   
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:t"
            mc:Ignorable="d"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <Button x:Name="button" Content="send Request" HorizontalAlignment="Left" Margin="229,25,0,0" VerticalAlignment="Top" Width="92" Click="button_Click"/>
            <Button x:Name="button1" Content="autenticate new device" HorizontalAlignment="Left" Margin="229,62,0,0" VerticalAlignment="Top" Width="92" Click="button1_Click" />
            <Button x:Name="button2" Content="send Message" HorizontalAlignment="Left" Margin="229,151,0,0" VerticalAlignment="Top" Width="92" Click="button2_Click" />
    
            <TextBox x:Name="txtAutCode" HorizontalAlignment="Left" Height="23" Margin="229,108,0,0" TextWrapping="Wrap" Text="123" VerticalAlignment="Top" Width="92"/>
    
        </Grid>
    </Window>
