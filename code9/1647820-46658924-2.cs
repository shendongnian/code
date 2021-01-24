foreach (var item in checkboxList) 
{ 
   if (!item.IsChecked) 
   {
       int index = myList.IndexOf(item);
       if(index != -1)
           myList.RemoveAt(index);
   }
}
