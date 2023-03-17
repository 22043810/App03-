using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
	/// <summary>
	/// Grades enumeration names and descriptions
	/// </summary>
	public class StudentGrades
	{
		// Constants (Grade Boundaries)

		public const int LowestMark = 0;
		public const int LowestGradeD = 40;
		public const int LowestGradeC = 50;
		public const int LowestGradeB = 60;
		public const int LowestGradeA = 70;
		public const int HighestMark = 100;

		// Properties
		public string[] Students { get; set; }

		public int[] Marks { get; set; }

		public int[] GradeProfile { get; set; }

		public double Mean { get; set; }

		public int Minimum { get; set; }

		public int Maximum { get; set; }


		// Attributes

		public StudentGrades()
		{
			Students = new string[]
			{
				"Uthman", "Haris", "Aadhi", "Entwan", "Euan",
				"Bruno", "Crown", "Imaan", "Jess", "Mustafa"
			};

			GradeProfile = new int[(int)Grades.A + 1];
			Marks = new int[Students.Length];
		}

		public void Run()
		{
			SelectUnit();

		}

		public void SelectUnit()
		{
			string[] choices = new string[]
			{
				"Input Marks",
				"Output Marks",
				"Output Stats",
				"Output Grade Profile",
				"Quit"
			};

			int choice = ConsoleHelper.SelectChoice(choices);
			switch (choice)
			{
				case 1:
					InputMarks();
					break;
				case 2:
					OutputMarks();
					break;
				case 3:
					CalculateStats();
					break;
				case 4:
					OutputGradeProfile();
					break;
				case 5:
					Quit();
					break;
				default:
					Console.WriteLine("Invalid choice.");
					break;
			}
			Console.WriteLine();
			SelectUnit();
		}

		private void Quit()
		{
			Environment.Exit(0);
		}

		public void InputMarks()
		{
			for (int i = 0; i < Students.Length; i++)
			{
				Console.WriteLine($"Enter mark for student {Students[i]}: ");
				Marks[i] = Convert.ToInt32(Console.ReadLine());
			}
		}

		public void OutputMarks()
		{
			ConsoleHelper.OutputHeading("Marks for each Student");

			for (int i = 0; i < Students.Length; i++)
			{
				int mark = Marks[i];
				Grades grades = ConvertToGrade(mark);
				Console.WriteLine($"Student Name: {Students[i]}\tStudent Mark: {mark}\t"
				+ $"Student Grade: {grades}\t");
			}
			Console.WriteLine();
			ConsoleHelper.OutputHeading("Please Enter Student Marks");
			SelectUnit();
		}

		public Grades ConvertToGrade(int mark)
		{
			if (mark >= 0 && mark < LowestGradeD)
			{
				return Grades.F;
			}
			else if (mark >= LowestGradeD && mark < LowestGradeC)
			{
				return Grades.D;
			}
			else if (mark >= LowestGradeC && mark < LowestGradeB)
			{
				return Grades.C;
			}
			else if (mark >= LowestGradeB && mark < LowestGradeA)
			{
				return Grades.B;
			}
			else if (mark >= LowestGradeA && mark <= HighestMark) // add condition for highest grade
			{
				return Grades.A;
			}
			else
			{
				throw new ArgumentException("Invalid mark");
			}
		}

			public void CalculateStats()
			{
				if (Marks.Length == 0)
				{
					Console.WriteLine("No marks have been entered yet.");
					return;
				}

				double total = 0;
				Minimum = Marks[0];
				Maximum = Marks[0];

				foreach (int mark in Marks)
				{
					total += mark;
					if (mark < Minimum)
					{
						Minimum = mark;
					}
					if (mark > Maximum)
					{
						Maximum = mark;
					}
				}

				Mean = total / Marks.Length;

				Console.WriteLine($"Mean mark: {Mean:F2}");
				Console.WriteLine($"Minimum mark: {Minimum}");
				Console.WriteLine($"Maximum mark: {Maximum}");
			}
		public void OutputGradeProfile()
		{
			ConsoleHelper.OutputHeading("Grade Profile");

			Console.WriteLine("Grades\tCount\tPercentage");
			Console.WriteLine("--------------------------------");
			CalGradeProfile();
			int totalGrades = GradeProfile.Sum(); // calculate the total number of grades

			for (int i = 0; i < GradeProfile.Length; i++)
			{
				Grades grade = (Grades)i;
				int count = GradeProfile[i];
				double percentage = (double)count / totalGrades * 100;
				Console.WriteLine($"{grade}\t{count}\t{percentage}%");
			}
		}
		public void CalGradeProfile()
		{
			for (int i= 0; i < GradeProfile.Length; i++)
			{
				GradeProfile[i] = 0;
			}
			foreach(int mark in Marks)
			{
				Grades grade = ConvertToGrade(mark);
				GradeProfile[(int)grade]++;
			}
		}
	}
}


