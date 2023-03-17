using ConsoleAppProject.App01;
using ConsoleAppProject.App03;
using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start App01 to App05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Mustafa Akram 13/03/2023
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine(" Student Marks by Mustafa Akram ");
			Console.WriteLine(" version 0.1 ");
			Console.WriteLine(" =================================================");
            Console.WriteLine();

            //DistanceConverter converter = new DistanceConverter();
            //converter.run();

            StudentGrades con = new StudentGrades();
            con.Run();
        }
    }
}
