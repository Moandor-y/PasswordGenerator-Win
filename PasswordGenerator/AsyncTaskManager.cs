using System;
using System.Collections.Concurrent;
using System.Threading;

namespace PasswordGenerator
{
    internal static class AsyncTaskManager
    {
        private static readonly BlockingCollection<Action> Tasks =
            new BlockingCollection<Action>();

        private static readonly Thread BackgroundThread;

        static AsyncTaskManager()
        {
            BackgroundThread = new Thread(RunMessageLoop);
            BackgroundThread.Start();
        }

        private static void RunMessageLoop()
        {
            while (!Tasks.IsCompleted)
            {
                try
                {
                    Action action = Tasks.Take();
                    action();
                }
                catch (Exception)
                {
                    break;
                }
            }
        }

        public static void RunInBackground(Action action)
        {
            Tasks.Add(action);
        }

        public static void OnApplicationExit()
        {
            Tasks.CompleteAdding();
            BackgroundThread.Join();
        }
    }
}
