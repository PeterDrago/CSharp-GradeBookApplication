using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
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
    }
}
    
  

