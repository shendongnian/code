    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using TeleSharp.TL;
    using TLSharp.Core;
    using TLSharp.Core.Utils;
    namespace TLSharpTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Task.Run(async () => { await doTask(); });
                Console.ReadLine();
            }
            static async Task doTask()
            {
                var apiId = 1234; //apiId: get from https://my.telegram.org/apps
                var apiHash = "<apiHash>"; // get from https://my.telegram.org/apps
                var client = new TelegramClient(apiId, apiHash);
                await client.ConnectAsync();
        
                var phone = "<phone_number>";
                var hash = await client.SendCodeRequestAsync(phone);
                var code = "<sent_code_by_telegram>";
                var user = await client.MakeAuthAsync(phone, hash, code);
                //get available contacts
                var result = await client.GetContactsAsync();    
                //find recipient in contacts
                var specifiedUser = result.users.lists
                        .Where(x => x.GetType() == typeof(TLUser))
                        .Cast<TLUser>()
                        .FirstOrDefault(x => x.phone == "<recipient_phone>");
                // send file to the specified contact (sample from TLSharp github)
                var fileResult = (TLInputFile)await client.UploadFile("cat.jpg", new StreamReader("data/cat.jpg"));
                await client.SendUploadedPhoto(new TLInputPeerUser() { user_id = specifiedUser.id }, fileResult, "kitty");
            }
        }
    }
