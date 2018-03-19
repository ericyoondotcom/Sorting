using System;

namespace Sorting
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Random randy = new Random();
            /*int[] sortMe = new int[randy.Next(10, 101)];
            for(int i = 0; i < sortMe.Length; i++){
                sortMe[i] = randy.Next(-100, 101);
            }*/
            int[] sortMe = new int[16] {5, 7, 3, 6, 2, 6, 23, 8, 6, 2, 7, 17, 99, 46, 25, 86};
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (int i in sortMe) Console.Write(i.ToString() + ", ");
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\n\n**************\n*            *\n* SORTING... *\n*            *\n**************\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            sortMe = MySorter.MergeSort(sortMe, (x, y) => x - y);
            foreach (int i in sortMe) Console.Write(i.ToString() + ", ");

        }
    }
}
