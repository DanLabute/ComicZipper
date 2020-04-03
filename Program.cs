using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace ComicZipper
{
    class Program
    {
        static void Main()
        {
            string sourcePath = @".";
            string[] directoryList = Directory.GetDirectories(sourcePath, "*", SearchOption.TopDirectoryOnly);

            string folderName;
            string zipName;
            string sourceFileName;
            string destFileName;

            Console.WriteLine("Compressing Comics");
            Console.WriteLine("==================");
            foreach (string s in directoryList)
            {
                folderName = s;
                zipName = folderName + ".zip";
                if (!File.Exists(zipName))
                {
                    ZipFile.CreateFromDirectory(folderName, zipName);
                    Console.WriteLine("Created Zip: " + zipName);
                    sourceFileName = s;
                    destFileName = Path.GetDirectoryName(s) + @"\" + Path.GetFileNameWithoutExtension(s) + ".cbz";
                    if (!File.Exists(destFileName))
                    {
                        System.IO.File.Move(zipName, destFileName);
                        Console.WriteLine("Zip moved to Cbz: " + destFileName);
                        Directory.Delete(s, true);
                        Console.WriteLine("Deleted Folder: " + s);
                    }
                    else
                    {
                        Console.WriteLine("Skipped: " + destFileName + " (File already exists)");
                    }
                }
                else
                {
                    Console.WriteLine("Skipped: " + zipName + " (File already exists)");
                }
            }
            Console.WriteLine("Complete. Press any key to exit.");
            Console.ReadKey(true);
        }
    }
}
