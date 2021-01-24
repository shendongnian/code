        private async static Task ReceiveFileUploadNotificationAsync()
        {
            var notificationReceiver = serviceClient.GetFileNotificationReceiver();
            Console.WriteLine("\nReceiving file upload notification from service");
            while (true)
            {
                var fileUploadNotification = await notificationReceiver.ReceiveAsync();
                if (fileUploadNotification == null) continue;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Received file upload noticiation: {0}", string.Join(", ", fileUploadNotification.BlobName));
                Console.ResetColor();
                await notificationReceiver.CompleteAsync(fileUploadNotification);
            }
        }
