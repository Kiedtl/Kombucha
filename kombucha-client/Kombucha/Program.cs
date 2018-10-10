using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression.FileSystem;
using System.Net;
using Sentry;

using Kombucha.Command;
using Kombucha.Error;

namespace Kombucha
{
    class Program
    {
        private void Main(string[] args)
        {
            using (SentrySdk.Init("https://c9f149c50f4b40b98191e621f79e3669@sentry.io/1294828"))
            {
                try
                {
                    // get command line arguments
                    string command = args[0];
                    string value = args[1];
                    string flag1 = args[2];

                    if (String.IsNullOrEmpty(command))
                    {
                        Print.PrintOut(Print.Level.ERROR, "1 or more arguments required by Kombucha.");
                    }

                    // check command variable
                    if (command == "install" || command == "fill" || command == "i") /* Install a bottle */
                    {
                        Install.InstallPackage(value);
                    }
                    else if (command == "install-multiple" || command == "fill-multiple" || command == "im")
                    {
                        string[] bottles = new string[args.Length - 1];
                        for (int i = 0; i == args.Length - 1; i++)
                        {
                            bottles[i] = args[i + 1];
                        }
                        Install.InstallMultiple(bottles.Length, bottles);
                    }
                    else if (command == "run" || command == "drink" || command == "r") /* Execute the binary of a bottle that was installed previously */
                    {
                        Run.RunPackage(value);
                    }
                    else if (command == "info" || command == "view-label") /* View the author, README, name, etc. of a bottle */
                    {
                        Info.InfoPackage(value, flag1);
                    }
                    else if (command == "update" || command == "refill" || command == "u") /* Update a bottle that was installed previously */
                    {
                        // TODO: Implement command UPDATE
                        throw new NotImplementedException;
                    }
                    else if (command == "search" || command == "lookup" || command == "s")
                    {
                        // TODO: Implement command SEARCH
                        throw new NotImplementedException;
                    }
                    else if (command == "try" || command == "taste" || command == "t")
                    {
                        // TODO: Implement command TRY
                        throw new NotImplementedException;
                    }
                    else if (command == "clean" || command == "dishwasher" || command == "c")
                    {
                        // TODO: Implement command CLEAN
                        throw new NotImplementedException;
                    }
                    else if (command == "moo")
                    {
                        Print.PrintOut(Print.Level.INFORMATION, "I am moo, how are you?");
                        Print.PrintOut(Print.Level.INFORMATION, @"             (__)  ");
                        Print.PrintOut(Print.Level.INFORMATION, @"             (oo)  ");
                        Print.PrintOut(Print.Level.INFORMATION, @"    /---------\/   ");
                        Print.PrintOut(Print.Level.INFORMATION, @"   / |       ||    ");
                        Print.PrintOut(Print.Level.INFORMATION, @"  *  ||------||    ");
                        Print.PrintOut(Print.Level.INFORMATION, @"     ^^      ^^    ");
                    }
                    else
                    {
                        Print.PrintOut(
                            Print.Level.ERROR,
                            "\n\nError KE00A: Kombucha does not recognize the following command: " +
                            command
                        );
                    }
                }
                catch (Exception e)
                {
                    SentryErrorHandle.ReportErrorToSentry(e);
                }
            }
        }
    }
}

/* τέλος - THE END
 *
 *
 *                  █
 *                █         ██                            / █
 *  /██████    /███████     / █        /█████     /█████████
 * |_  ██_/   /██__        / ███     | ██  | ██ | ██ ________/
 *   | ██    | ████       / ██ ██    | ██  | ██ | ██
 *   | ██  /█| ██______  / ██    ██  | ██  | ██ | ██
 *   |  ████/|  ███████ / ██      ██ |  ██████  |  █████████
 *    \___/   \_______//___/  ______/ \______/   \____     █
 *                                                   |  ███
 *                                                    \____
 *
 *
 */
