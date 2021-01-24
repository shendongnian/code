    private bool ConfirmOperation(string Object)
        {
            if (Object != "AABBCCDD")
            {
                if (Object == "user_Click_no")
                {
                    return false;
                }
                bool TheResultFromTheAlertDialog = false;
                AlertDialog.Builder AlertDialog = new AlertDialog.Builder(this);
                AlertDialog.SetTitle("Warning!");
                AlertDialog.SetMessage("Do you want to proceed with the operation?");
                AlertDialog.SetNegativeButton("No", (senderAlert, args) => {
                    Message message = mHandler.ObtainMessage();
                    message.What = 1;
                    mHandler.SendMessage(message);
                });
                AlertDialog.SetPositiveButton("Yes", (senderAlert, args) => {
                    Message message = mHandler.ObtainMessage();
                    message.What = 0;
                    mHandler.SendMessage(message);
                });
                AlertDialog.Show();
                try { Looper.Loop(); } catch (Java.Lang.Exception e) { }
                return TheResultFromTheAlertDialog;//Actually, it didn't work
            }
            else
            {
                //It's true or user click yes.
                return true;
            }
        }
