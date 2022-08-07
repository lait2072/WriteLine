using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace WriteLine
{
    class Program
    {
        static private List<string> text = new List<string>();
        static private int letters = 1;
        static void Main(string[] args)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\read.txt"))
            {
                text = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\read.txt").ToList();
            }
            else
            {
                File.Create(Directory.GetCurrentDirectory() + "\\read.txt");
            }
            Work();            
        }

        private static void Work()
        {
            Console.WriteLine("Сколько символов печатать в секунду");
            try
            {
                letters = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Work();
            }
            Write();            
        }

        private static void Write()
        {
            for (int i = 0; i < text.Count; i++)
            {
                for (int j = 0; j < text[i].Length; j++)
                {
                    Console.Write(text[i].ToString()[j]);
                    Random rand = new Random();                    
                    Thread.Sleep(1000 / letters + rand.Next(-1000 / letters, 1000 / letters)+ 1);
                }
                Console.WriteLine();
            }
        }
    }
}
