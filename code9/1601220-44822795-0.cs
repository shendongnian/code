        private void CanvasLP_Drop(object sender, DragEventArgs e)
        {
           if (e.Handled == false)
            {
              Thumb thumb = (Thumb)e.Data.GetData("Object");
              //thumb is used to store the dropped item, as in my case it is of type Thumb 
              //Object here is the item being dragged
              //You can get file path from file name by using:
              //Path.Combine(Directory.GetCurrentDirectory(), filename)
               
            }
         }
