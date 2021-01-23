    if (!mainform.IsHandleCreated)
            {
                mainform.CreateControl();
                mainform.Loaded += (s, ea) =>
                {
                    mainform.amountdl.Invoke((MethodInvoker)(() => mainform.amountdl.Text = "Downloaded " + progress.ReceivedObjects + "/" + progress.TotalObjects));
                    if (progress.TotalObjects == progress.ReceivedObjects)
                    {
                        mainform.amountdl.Invoke((MethodInvoker)(() => mainform.amountdl.Text = "Configuring Files Please Wait."));
                    }
                };
            }
            else
            {
                mainform.amountdl.Invoke((MethodInvoker)(() => mainform.amountdl.Text = "Downloaded " + progress.ReceivedObjects + "/" + progress.TotalObjects));
                if (progress.TotalObjects == progress.ReceivedObjects)
                {
                    mainform.amountdl.Invoke((MethodInvoker)(() => mainform.amountdl.Text = "Configuring Files Please Wait."));
                }
            }
