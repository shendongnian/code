    using System;
    using System.Threading;
    namespace SO42323314
    {
        class Program
        {
            static void Main(string[] args)
            {
                WorkToDo ToDo = new WorkToDo();
                Timer ticker = new Timer(TimerCallback, ToDo, 0, 3000);
                ToDo.are.WaitOne();
            }
            /// <summary>
            /// This will be called every time the interval occurs
            /// </summary>
            /// <param name="ToDoObject"></param>
            static void TimerCallback(object ToDoObject)
            {
                WorkToDo ToDo = ToDoObject as WorkToDo;
                Console.WriteLine(ToDo.WorkDone);
                ++ToDo.WorkDone;
                if (ToDo.WorkDone > 3)
                    ToDo.are.Set(); // signal the AutoResetEvent
            }
        }
        class WorkToDo
        {
            public int WorkDone = 0;
            // initialize the AutoResetEvent to not signaled
            public AutoResetEvent are = new AutoResetEvent(false);
        }
    }
