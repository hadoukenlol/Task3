using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class DirectoryExtension
    {
        public static long DirSize(DirectoryInfo dir)
        {
            long size = 0;
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                size += file.Length;
            }
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo item in dirs)
            {
                size += DirSize(item);
            }
            return size;
        }
    }
}
