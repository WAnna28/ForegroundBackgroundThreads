using ForegroundBackgroundThreads.Models;
using System;
using System.Threading;

namespace ForegroundBackgroundThreads
{
    // • Foreground threads can prevent the current application from terminating.The.NET
    // Core Runtime will not shut down an application(which is to say, unload the hosting
    // AppDomain) until all foreground threads have ended.

    // • Background threads (sometimes called daemon threads) are viewed by the.NET
    // Core Runtime as expendable paths of execution that can be ignored at any point
    // in time (even if they are currently laboring over some unit of work). Thus, if all
    // foreground threads have terminated, all background threads are automatically killed
    // when the application domain unloads.
    //
    // By default, every thread you create via the Thread.Start() method is automatically a
    // foreground thread.
    class Program
    {        
        static void Main()
        {
            Console.WriteLine("***** Background Threads *****\n");
            Printer p = new Printer();

            Thread bgroundThread = new Thread(new ThreadStart(p.PrintNumbers));
            
            // This is now a background thread.
            bgroundThread.IsBackground = true;
            bgroundThread.Start();

            Console.ReadLine();
        }
    }
}