﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students");
            }
            List<double> grades = new List<double>();
            foreach (var student in Students)
            {
                grades.Add(student.AverageGrade);
            }
            grades.Sort((a, b) => -1* a.CompareTo(b));
            int threshold =(int)(Students.Count * 0.2);
            if (grades[threshold - 1] <= averageGrade)
            {
                return 'A';
            }
            if (grades[threshold * 2 -1] <= averageGrade)
            {
                return 'B';
            }
            if (grades[threshold * 3 - 1] <= averageGrade)
            {
                return 'C';
            }
            if (grades[threshold * 4 -1] <= averageGrade)
            {
                return 'D';
            }
            return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5) 
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else 
            {
                base.CalculateStatistics();
            }
            return;
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
            return;
        }
    }
}
    
  

