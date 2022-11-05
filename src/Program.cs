using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtaPJPGReplacer
{
    static class Program
    {
        private const int fileSize = 528192;
        private static byte[] outputData;

        static void Main(string[] args)
        {
            try
            {
                int offset = 0x124;

                string mainFilePath = $"{Directory.GetFiles(Environment.CurrentDirectory, "PGTA5*")[0]}";
                string imgJpgPath = $"{Directory.GetFiles(Environment.CurrentDirectory, "*.jpg")[0]}";

                Console.WriteLine(mainFilePath);
                Console.WriteLine(imgJpgPath);

                byte[] fileBytes = File.ReadAllBytes(mainFilePath);
                Console.WriteLine($"Size of {Path.GetFileName(mainFilePath)}: {fileBytes.Length} bytes");
                byte[] imgJpgBytes = File.ReadAllBytes(imgJpgPath);
                Console.WriteLine($"Size of {Path.GetFileName(imgJpgPath)}: {imgJpgBytes.Length} bytes");

                for (int i = 0; i < imgJpgBytes.Length; i++)
                {
                    fileBytes[offset + i] = imgJpgBytes[i];
                }

                File.WriteAllBytes($"{Directory.GetFiles(Environment.CurrentDirectory, "PGTA5*")[0]}", fileBytes);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().Name}\n{e.Message}\n{e.StackTrace}");
            }

            Console.ReadKey();
        }
    }
}
