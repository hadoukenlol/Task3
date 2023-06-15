using System.Drawing;
using System.IO;

namespace Task3
{
    internal class Program
    {
        public static long size = 0;
        public static int fileCount = 0;
        static void Main(string[] args)
        {
            var Dir = new DirectoryInfo("D://dirDeleting/");
            var Directories = Dir.GetDirectories();
            ShowDirectoryInfo(Directories);
            ShowFileInfo(Dir);
            Console.WriteLine($"Общий вес папки: {size}") ;
            DeleteFiles(Dir);
            Console.WriteLine($"Удалено файлов - {fileCount}");
            ShowDirectoryInfo(Directories);
            Console.WriteLine($"Общий вес папки после удаления: {size}");
        }
        static void DeleteFiles(DirectoryInfo dir)
        {            
            try
            {
                foreach (DirectoryInfo diritem in dir.GetDirectories())
                {
                    DeleteFiles(diritem);
                    var str = diritem.LastAccessTimeUtc;
                    var str2 = DateTime.Now;
                    var diff = str2.Subtract(str).Minutes;
                    if (diff > 1) diritem.Delete();
                    Console.WriteLine(diritem.FullName);
                }
                foreach (FileInfo file in dir.GetFiles())
                {
                    var str = file.LastAccessTimeUtc;
                    var str2 = DateTime.Now;
                    var diff = str2.Subtract(str).Minutes;
                    fileCount++;
                    Console.WriteLine(file.FullName);
                    if (diff > 1) file.Delete();
                }
                size = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void ShowDirectoryInfo(DirectoryInfo[] rootDir)
        {
            foreach (var Dir in rootDir)
            {
                try
                {
                    size += DirectoryExtension.DirSize(Dir);
                }
                catch (Exception e)
                {
                    Console.WriteLine(Dir.Name + $" - Не удалось скачать - {e.Message}");
                }
            }
        }

        public static void ShowFileInfo(DirectoryInfo rootDir)
        {
            foreach (var item in rootDir.GetFiles())
            {
                size += item.Length;
            }
        }

    }
}