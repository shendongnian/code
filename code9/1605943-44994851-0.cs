    namespace Awesome.Android {
         public class AwesomeFragment : Fragment {
            
           public delegate void OnAwesomePress (int number);
           public event OnAwesomePress sendOnAwesomePressEvent;
         }
    }
