using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;


namespace aba
{
    class Program
    {
        static StreamWriter sw;
        static StreamReader sr;
        static void Main(string[] args)
        {
            Console.WriteLine("Номер задания");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    one();
                    break;
                case 2:
                    two();
                    break;
                case 3:
                    three();
                    break;
                case 5:
                    five();
                    break;
            }
        }
        static void one()
        {
            DirectoryInfo dir = new System.IO.DirectoryInfo(@"C:\Users\r2d2\source\laba6_Temp");
            dir.Create();
            File.Copy(@"D:\lab.dat", @"C:\Users\r2d2\source\laba6_Temp\lab_backup.dat", true);
            DirectoryInfo dinf = new DirectoryInfo(@"C:\Users\r2d2\source\laba6_Temp");
            FileInfo[] finf = dinf.GetFiles();
            foreach (FileInfo fi in finf)
            {
                Console.WriteLine();
                Console.WriteLine(fi.FullName.ToString());
                Console.WriteLine("Размерa файла:{0} B", fi.Length);
                Console.WriteLine("Время последнего изменения: {0}", fi.CreationTime);
                Console.WriteLine("Время последнего доступа: {0}", fi.LastAccessTime);
                Console.WriteLine();
                Console.ReadKey();
            }
        }


        static void two()
        {
            string path = @"D:\Lab2";
            string path1 = @"D:\Lab2\\lab.dat";
            string path2 = @"D:\Lab2\\lab2.dat";
            string one = String.Empty;
            sw = new StreamWriter(path1);
            for (int i = 1; i <= 100; i++)
            {
                sw.WriteLine(one += i + " - 2^" + i + "\n");
            }
            sw.Close();
            List<String> mass = new List<string>();
            sr = new StreamReader(path1);
            //while (true)
            //{
            //    string line = sr.ReadLine();
            //    if (line != null)
            //    {
            //        mass.Add(line);
            //    }
            //    else
            //    {
            //        break;
            //    }
            //    }
                int numbers = 0;
                sw = new StreamWriter(path2);    
                foreach (string item in mass)                 
                {
                
                if (numbers % 2 == 0)                      
                    {
                        sw.WriteLine(item);                
                    }
                numbers++;
                }


            sw.Close();
            Console.ReadKey();
        }
        static void three()
        {
            string path1 = @"D:\\laba3.txt";
            string path2 = @"D:\\laba3-2.txt";
            string newText = "";
            int count = 0;
            string[] text = File.ReadAllLines(path1);
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != "")
                    newText += text[i] + "\n";
                else if (text[i++] != "")
                {
                    newText += "\n" + text[i++] + "\n";
                    i++;
                }
                else
                    count++;
            }
            File.WriteAllLines(path2, newText.Split('\n'));
            Console.WriteLine();
            Console.WriteLine("Количество удаленных пустых строк - " + count);
            Console.ReadLine();
        }
        static void five()
        {
            Console.WriteLine("Введите 1");
            string path = @"D:\octocat1.bmp";
            BinaryReader picture = new BinaryReader(new FileStream(path, FileMode.Open));
            picture.ReadChars(2);
            int size = picture.ReadInt32();
            Console.WriteLine("Size: {0} byte", size);
            picture.ReadInt16();
            picture.ReadInt16();
            picture.ReadInt32();
            picture.ReadInt32();
            int width = picture.ReadInt32();
            Console.WriteLine("Width in pixels: {0} pixels", width);
            int height = picture.ReadInt32();
            Console.WriteLine("Height in pixels: {0} pixels", height);
            picture.ReadInt16();
            short bitPerPixel = picture.ReadInt16();
            Console.Write("Bit/pixel: {0}, ", bitPerPixel);
            if (bitPerPixel == 1)
                Console.WriteLine("monochrome palette, 2 colours");
            if (bitPerPixel == 4)
                Console.WriteLine("4bit palletized, 16 colours");
            if (bitPerPixel == 8)
                Console.WriteLine("8bit palletized, 256 colours");
            if (bitPerPixel == 16)
                Console.WriteLine("16bit RGB, 65536 colours");
            if (bitPerPixel == 24)
                Console.WriteLine("24bit RGB, 16M colours");
            int compressionType = picture.ReadInt32();
            if (compressionType == 0)
                Console.WriteLine("Compression type: without compression");
            if (compressionType == 1)
                Console.WriteLine("Compression type: 8 bit RLE compression");
            if (compressionType == 2)
                Console.WriteLine("Compression type: 4 bit RLE compression");
            picture.ReadInt32();
            int gorizontalResolution = picture.ReadInt32();
            Console.WriteLine("Gorizontal resolution: {0} pixels/m", gorizontalResolution);
            int verticalResolution = picture.ReadInt32();
            Console.WriteLine("Vertical resolution: {0} pixels/m", verticalResolution);
            Console.ReadKey();
        }
    }
}
    
