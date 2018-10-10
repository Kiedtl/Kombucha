using System;

namespace Kombucha.IO
{
    class IOFunc
    {
        public string[] readLineByLine(string path, int lines)
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
    }
}
