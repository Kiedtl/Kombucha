using System;

namespace Kombucha
{
    class Print
    {

        public enum Level
        {
            VERBOSE,
            INFORMATION,
            WARNING,
            ERROR
        }

        public static void PrintOut(Level printtype, string contents)
        {
            if (printtype == Level.VERBOSE)
            {
                printVerbose(contents);
            }
            else if (printtype == Level.INFORMATION)
            {
                printInfo(contents);
            }
            else if (printtype == Level.WARNING)
            {
                printWarning(contents);
            }
            else if (printtype == Level.ERROR)
            {
                printError(contents);
            }
            else
            {
                throw new ArgumentException("Not implemented for the requested Level");
            }
        }

        // PRIVATE STUFF
        private static void printError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
            Console.ResetColor();
        }
        private static void printWarning(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(text);
            Console.ResetColor();
        }
        private static void printInfo(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(text);
            Console.ResetColor();
        }
        private static void printVerbose(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
