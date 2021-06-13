using System;
using System.IO;

namespace ZavrsniRad.Lib
{
    class Logger
    {
        private static string logFilename = @"C:\Kurs\ZavrsniRad.log";

        public static void setFileName(string fileName)
        {
            logFilename = fileName;
        }

        public static void empty()
        {
            File.WriteAllText(logFilename, string.Empty);
        }



        private static void writeLog(string logMessage)
        {
            using (StreamWriter fileHandle = new StreamWriter(logFilename, true))
            {
                fileHandle.WriteLine(logMessage);
            }
        }


        public static void log(string messageType, string logMessage)
        {
            writeLog($"[{ DateTime.Now}],{ messageType}:");

        }

        private static string separator(char character = '=')
        {
            return new string(character, 100);
        }

        public static void beginTest(string testName)
        {
            writeLog(separator());
            writeLog($"Starting test:{testName}");

        }

        public static void endTest()
        {
            writeLog(separator());
        }
    }
}
