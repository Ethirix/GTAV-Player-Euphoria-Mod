using System;
using System.Diagnostics;
using System.IO;

namespace Euphorically.Debugging
{
    internal class Logger
    {
        [Conditional("DEBUG")]
        public static void LogToFile(string message)
        {
            File.AppendAllText("Euphorically.log", message + Environment.NewLine);
        }
    }
}