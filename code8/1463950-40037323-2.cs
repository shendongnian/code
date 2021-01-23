    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Channels;
    using System.Text;
    using System.Threading.Tasks;
    using SKYPE4COMLib;
    namespace skypeExperiment
    {
        class Program
        {	
            static void Main(string[] args)
            {
                Skype s = new Skype();
                s.Attach();
                if (!s.Client.IsRunning)
                {
                    // start minimized with no splash screen
                    s.Client.Start(true, true);
                }
                // wait for the client to be connected and ready
                //you have to click in skype on the "Allow application" button which has popped up there
                //to allow this application to communicate with skype
                s.Attach(6, true);
                //this will print out all the chat names to the console
                //it will enumerate all the chats you've been in
                foreach (Chat ch in s.Chats)
                {
                    Console.WriteLine(ch.Name);
                }
                //pick one chat name of the enumerated ones and get the chat object
                string chatName = "#someskypeuser/someskypeuser;9693a13447736b9";
                Chat chat = GetChatByName(s, chatName);
                //send a message to the selected chat
                if (chat != null)
                {
                    chat.SendMessage("test");
                }
                else
                {
                    Console.WriteLine("Chat with that name was not found.");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            private static Chat GetChatByName(Skype client, string chatName)
            {
                foreach (Chat chat in client.Chats)
                {
                    if (chat.Name == chatName) return chat;
                }
                return null;
            }
        }
    }
