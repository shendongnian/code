        try
        {
            send_socket.Bind(send_point);
            send_socket.Connect(connected_point);
            byte[] data = Encoding.Unicode.GetBytes("TestTest");
            send_socket.Send(data);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            send_socket.Close();
        }
