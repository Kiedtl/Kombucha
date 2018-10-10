using System;
using Kombucha.Print;

namespace Kombucha.Command
{
    class Install
    {
        public void InstallMultiple(int number, string[] bottles)
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
                InstallPackage(bottle);
            }
        }


        public void InstallPackage(string package)
        {
            Print.PrintOut(
                Print.Level.INFORMATION,
                "Installing bottle"
                + secondArg
            );
            string json = Net.SendGetRequest(
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
    }
}
