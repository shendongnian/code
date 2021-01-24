    enter  ReportObject ro = new ReportObject()
         {
           Name = ctrl.Name,
           BackColor = ctrl.BackColor,
           ForeColor = ctrl.BackColor,
           Fonts = ctrl.Font,
           TypeofControl = ctrl.GetType()
         };
         MemoryStream memorystream = new MemoryStream();
         BinaryFormatter bf = new BinaryFormatter();
         bf.Serialize(memorystream, ro);
        byte[] yourBytesToDb = memorystream.ToArray();
