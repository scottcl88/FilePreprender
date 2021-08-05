using System;
using System.IO;
using System.Linq;
using System.Text;

namespace FilePreprender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string folder = @"\\repos\FoodAngular\food-app\src";
            string text = "Copyright 2021 Scott Lewis, All rights reserved.";
            PrependText(folder, text);
            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        private static void PrependText(string folder, string text)
        {
            string[] files = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories).Where(x => x.ToLower().EndsWith(".txt") || x.ToLower().EndsWith(".ts") || x.ToLower().EndsWith(".html") || x.ToLower().EndsWith(".scss")).ToArray();
            Console.WriteLine($"Found {files.Length} files to edit..."); 
            foreach (var file in files)
            {
                string currentContent = String.Empty;
                if (File.Exists(file))
                {
                    currentContent = File.ReadAllText(file);
                }
                StringBuilder preprendText = new StringBuilder();
                if (file.ToLower().EndsWith(".html"))
                {
                    preprendText.Append("<!--");
                    preprendText.AppendLine();
                    preprendText.Append(text);
                    preprendText.AppendLine();
                    preprendText.Append("-->");
                    preprendText.AppendLine();
                }
                else
                {
                    preprendText.Append("/**");
                    preprendText.AppendLine();
                    preprendText.Append(text);
                    preprendText.AppendLine();
                    preprendText.Append("**/");
                    preprendText.AppendLine();
                }
                File.WriteAllText(file, preprendText.ToString() + currentContent);
            }
        }
    }
}
