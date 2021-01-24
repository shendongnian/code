            string s = "<Hello it´s me, <Hi  how are you <hay";
            List<string> ValidList = new List<string>() { "Hello", "hay" };
            var arr = s.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr.Length; i++)
            {
                bool flag = false;
                foreach (var item in ValidList)
                {
                    if (arr[i].Contains(item))
                    {
                        flag = false;
                        break;
                    }
                    else
                    {
                        flag = (flag) ? flag : !flag;
                    }
                }
                if (flag)
                    arr[i] = "?" + arr[i];
                else
                    arr[i] = "<" + arr[i];
            }
            Console.WriteLine(string.Concat(arr));
