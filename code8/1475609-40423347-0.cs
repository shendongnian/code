    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.ObjectModel;
    namespace Rextester
    {
        public class Program
        {
           public static void Main(string[] args)
           {
                ObservableCollection<string> strList = new ObservableCollection<string>{"1", "2"};
                strList.CollectionChanged += onCollectionChange;
                //strList.Clear();
                var strList2 = new ObservableCollection<string>{"1", "2", "3"};
                Merge(strList,strList2);
            }
    
    		public static void Merge<T>(ICollection<T> a, ICollection<T> b) {
    			var diff = b.Except(a).ToList();
    			diff.ForEach(a.Add);
    		}
    		
           public static void onCollectionChange(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e){
                Console.WriteLine("Changed");
            }
        }
    }
