using System;

namespace Kombucha.Command
{
    class Run
    {
        public void RunPackage(string bottle)
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
    }
}
