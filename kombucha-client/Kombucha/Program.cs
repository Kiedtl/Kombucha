using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression.FileSystem;
using System.Net;
using Sentry;

namespace Kombucha
{
    class Program
    {

        #region MAIN
        private void Main(string[] args)
        {

            using (SentrySdk.Init("https://c9f149c50f4b40b98191e621f79e3669@sentry.io/1294828"))
            {
                // app code here

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
                    commandInstall(value);
                }
                else if (command == "install-multiple" || command == "fill-multiple" || command == "im")
                {
                    string[] bottles = new string[args.Length - 1];
                    for (int i = 0; i == args.Length - 1; i++)
                    {
                        bottles[i] = args[i + 1];
                    }
                    commandInstallMultiple(bottles.Length, bottles);
                }
                else if (command == "run" || command == "drink" || command == "r") /* Execute the binary of a bottle that was installed previously */
                {
                    commandRun(value);
                }
                else if (command == "info" || command == "view-label") /* View the author, README, name, etc. of a bottle */
                {
                    commandInfo(value, flag1);
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
        }
        #endregion

        #region COMMAND_IMPLEMENTATIONS

        private void commandInstallMultiple(int length, string[] bottles)
        {
            Print.PrintOut(
                Print.Level.INFORMATION,
                "\nInstalling " +
                length.ToString() +
                " bottles.\n\n"
            );
            foreach (string bottle in bottles)
            {
                Print.PrintOut(
                    Print.Level.INFORMATION,
                    "Installing bottle " +
                    bottle
                );
                commandInstall(bottle);
            }
        }

        private void commandInstall(string secondArg)
        {
            Print.PrintOut(
                Print.Level.INFORMATION,
                "Installing bottle"
                + secondArg
            );
            string json = sendGETRequest(
                "http://" +
                "github" +
                ".com/" +
                "Kiedtl/Kombucha/kombucha-shelf/" +
                secondArg
                + "/bottle.json"
            );
            else
            {
                //TODO: install bottle command
                string culturedata = downloadData(cultureloc);
                Stream file = File.Create(
                    "C:\\Users\\Public\\Kombucha\\Fridge\\" +
                    secondArg +
                    "\\culture.sml"
                );

                /* First save the culture file, then read it line by line */
                StreamWriter sw = new StreamWriter(file);
                sw.Write(culturedata);
                sw.Flush();
                sw.Close();

                // start Reading
                string[] data = readLineByLine(
                    "C:\\Users\\Public\\Kombucha\\Fridge\\" + secondArg + "\\culture.sml",
                    11
                );
                string bottlefile = data[5] + data[6];
                string bottlepacked = downloadData(bottlefile);
                Stream packfile = File.Create(
                    "C:\\Users\\Public\\Kombucha\\Fridge\\" +
                    secondArg +
                    "\\" +
                    data[6]
                );

                // save the bottled file
                StreamWriter ssw = new StreamWriter(packfile);
                ssw.Write(bottlepacked);
                ssw.Flush();
                ssw.Close();

                // Extract the ZIP file now
                ZipFile.ExtractToDirectory(
                    sourceArchiveFileName: packfile,
                    destinationDirectoryName: "C:\\Users\\Public\\Kombucha\\Fridge\\" + secondArg + "\\" + data[11] + "\\"
                );

                //TODO: add shortcut to the Start Menu and Desktop

                // Add to the FridgeFile
                StreamWriter sswd = File.AppendText(
                    "C:\\Users\\Public\\Kombucha\\Fridge\\fridgefile.sml"
                );
                sswd.WriteLine(
                    secondArg
                );
                sswd.Flush();
                sswd.Close();

                //Tell the user that the operation was successful
                Print.PrintOut(
                    Print.Level.INFORMATION,
                    "The bottle " +
                    secondArg +
                    " was successfully downloaded, extracted, and installed."
                );

            }
        }

        private void commandRun(string secondArg)
        {
            string[] data = new string[12];

            data = readLineByLine(
                "C:\\Users\\Public\\Kombucha\\Fridge\\" +
                secondArg +
                "\\culture.sml",
                11
            );
            string EXE =
                "C:\\Users\\Public\\Kombucha\\Fridge\\" +
                secondArg +
                "\\" +
                data[11] +
                "\\" +
                data[7];
            if (File.Exists(EXE))
            {
                Print.PrintOut(
                    Print.Level.INFORMATION,
                    "Starting bottle " +
                    secondArg
                );
                Process.Start(EXE);
            }
            else
            {
                Print.PrintOut(Print.Level.ERROR, "\nError KE020: The bottle requested does not exist.\n");
            }
        }

        private void commandInfo(string secondArg, string option)
        {

            string name,
            author,
            repo,
            homepage,
            version,
            readme,
            readmedata
            ;
            string[] data = new string[12];

            data = readLineByLine(
                "C:\\Users\\Public\\Kombucha\\Fridge\\" +
                secondArg +
                "\\culture.sml",
                12
            );

            name = data[0];
            author = data[1];
            repo = data[2];
            homepage = data[3];
            version = data[11];
            readme = data[12];

            System.Random random = new System.Random();
            int ran = random.Next(0, 100000);

            readmedata = downloadData(readme);
            string filename = "C:\\Users\\Public\\Kombucha\\temp\\" + secondArg + "_info_temp_" + ran.ToString() + ".htm";

            if (option == "--browser" || option == "--html")
            {
                StreamWriter sw = new StreamWriter(filename);

                sw.Write(
                    "<!doctype html> <html> <head> </head> <body> <h1>" +
                    name +
                    " " +
                    version +
                    "</h1>\n<h2>" +
                    name +
                    "   |   " +
                    author +
                    "   |   " +
                    repo +
                    "   |   " +
                    "</h2>\n<p>" +
                    readmedata +
                    "\n</p></body></html><!----τέλος---->"
                );

                if (option == "--browser")
                {

                    System.Diagnostics.Process.Start(filename);
                }
                else
                {
                    Print.PrintOut(Print.Level.INFORMATION, "Information written to the file " + filename);
                }

            }
            else if (option == "--console")
            {
                Console.WriteLine(
                    name +
                    " " +
                    version +
                    "\n" +
                    name +
                    "   |   " +
                    author +
                    "   |   " +
                    repo +
                    "   |   " +
                    homepage +
                    "\n\n" +
                    readmedata
                );
            }
            else
            {
                Print.PrintOut(Print.Level.WARNING, "WARNING: No option given, defaulting to --console");
                Console.WriteLine(
                    name +
                    " " +
                    version +
                    "\n" +
                    name +
                    "   |   " +
                    author +
                    "   |   " +
                    repo +
                    "   |   " +
                    homepage +
                    "\n\n" +
                    readmedata
                );
            }
        }

        private void continueCommandNew(string author, string email, string name, string culture, string homepage, string repo)
        {
            //TODO
            if (String.IsNullOrEmpty(author) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(name) || String.IsNullOrEmpty(culture) || String.IsNullOrEmpty(homepage) || String.IsNullOrEmpty(repo))
            {
                Print.PrintOut(
                    Print.Level.ERROR,
                    "Error KE001:" +
                    " Fields in the culture file cannot be null or empty." +
                    "\n"
                );
            }
            else
            {
                string url = "http://kombucha-internal.000webhostapp.com/client-commands/create-new.php?author=" +
                    author +
                    "?repo=" +
                    email +
                    "?name=" +
                    name +
                    "?culture=" +
                    culture +
                    "?homepage=" +
                    homepage +
                    "?repo=" +
                    repo;
                string response = sendGETRequest(url);
                Console.WriteLine(
                    "\n\n{0}",
                    response
                );
            }
        }
        #endregion

        #region UTILITY_FUNCTIONS

        private string downloadData(string url)
        {
            WebClient wc = new WebClient();
            byte[] res = wc.DownloadData(url);
            return System.Text.Encoding.UTF8.GetString(res);
        }

        private string sendGETRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            return resStream
                .ToString();
        }

        private void reportErrorToSentry(Exception err)
        {
            SentrySdk.CaptureException(err);
        }

        private string[] readLineByLine(string path, int lines)
        {
            int cultureLines = lines;
            int currentLine = 0;
            string cultureFile = path;
            string[] cultureData = new string[lines];
            if (File.Exists(cultureFile))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(
                        cultureFile
                    );
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        cultureData[currentLine] = line;
                        currentLine++;
                        if (currentLine == cultureLines)
                        {
                            break;
                        }
                    }
                }
                catch (UnauthorizedAccessException uae)
                {
                    Print.PrintOut(
                        Print.Level.ERROR,
                        "\nError KE002: Kombucha does not have permission to access the directory of file \"bottle.sml\" at path \"" +
                        cultureFile +
                        "\".\nError details: " +
                        uae.Message
                    );
                }
                catch (Exception e)
                {
                    Print.PrintOut(
                        Print.Level.ERROR,
                        "\nError KE00B: An unknown error occurred when Kombucha tried to access the file \"bottle.sml\" at path \"" +
                        cultureFile +
                        "\". \nPlease report this error.\nError details: " +
                        e.Message
                    );
                }
                finally
                {
                    if (file != null)
                    {
                        file.Close();
                    }
                }
            }

            return cultureData;
        }
        #endregion

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
