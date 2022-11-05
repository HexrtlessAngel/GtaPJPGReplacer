// Written by HeartlessAngel (Short but sloppy code, beware....)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// HeartlessAngel (me) is a bitch :)
namespace GtaPJPGReplacer
{
    static class Program
    {
        // :P
        static void Main(string[] args)
        {
            try
            {
                // Getting our file paths (Paathhhhzzzzzz, saying this word makes my tounge feel very disgusting for some odd reason lmfao)
                string mainFilePath = $"{Directory.GetFiles(Environment.CurrentDirectory, "PGTA5*")[0]}";
                string imgJpgPath = $"{Directory.GetFiles(Environment.CurrentDirectory, "*.jpg")[0]}";

                Console.WriteLine(mainFilePath);
                Console.WriteLine(imgJpgPath);

                // Read the files and store them in memory for now
                byte[] fileBytes = File.ReadAllBytes(mainFilePath);
                byte[] imgJpgBytes = File.ReadAllBytes(imgJpgPath);

                // Yep
                Console.WriteLine($"Size of {Path.GetFileName(mainFilePath)}: {fileBytes.Length} bytes");
                Console.WriteLine($"Size of {Path.GetFileName(imgJpgPath)}: {imgJpgBytes.Length} bytes");

                for (int i = 0; i < imgJpgBytes.Length; i++)
                {
                    // Replacing PGTA5's jpeg bytes with out custom jpg's (this is a very sloppy method but screw it, doing it)
                    fileBytes[0x124 + i] = imgJpgBytes[i];
                }

                // Now we can write the modified version of the image to the PGTA5 file
                File.WriteAllBytes($"{Directory.GetFiles(Environment.CurrentDirectory, "PGTA5*")[0]}", fileBytes);
            }
            catch (Exception e)
            {
                // Hello darkness my old friend
                Console.WriteLine($"{e.GetType().Name}\n{e.Message}\n{e.StackTrace}");
            }
        }
    }
}
