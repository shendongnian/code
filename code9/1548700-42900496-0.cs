    void WriteFaceLog(string userID, string faceId, string size, string valid, string template)
    {
        if (this.InvokeRequired) // you can use lstvFace instead of this, it doesn't matter as both are in same thread, you can also omit this
            this.Invoke((MethodInvoker)delegate { WriteFaceLog(userID, faceId, size, valid, template); });
        else
        {
        }
    }
