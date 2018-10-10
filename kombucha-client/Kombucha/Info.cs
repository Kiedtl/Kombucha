using System;

namespace Kombucha.Command
{
    class Info
    {
        public void InfoPackage(string bottle)
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
                    "\n</p></body></html><!----�????---->"
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
    }
}
