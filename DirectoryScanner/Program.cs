using System;
using System.IO;
using static System.Net.WebRequestMethods;

namespace DirectoryScanner { 
    internal class Program
    {
         static List<string> files;
        public static void Main(string[] args)
        {
            files  = new List<string>();
            string path = @"D:\TestFolder";
            RecurseDirectories(path);
            foreach (string i in files)
            {
                Console.WriteLine(i);
            }
            //Program program = new Program();
            //Console.WriteLine(program.files);
        }

        public static void RecurseDirectories(string path)
        {
            Program program = new Program();
            string[] directories = Directory.GetDirectories(path);

            bool isLast = false;
            foreach (string a in directories )
            {
                string[] directory = Directory.GetDirectories(a);
                if (directory.Length == 0 )
                {
                    files.Add(a);
                    isLast = true;
                }

                if (!isLast)
                {
                    files.Add(a);
                    RecurseDirectories(a);
                }
            }
            Console.WriteLine("");
        }
    }
}
