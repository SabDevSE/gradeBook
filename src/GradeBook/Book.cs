using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }

        }   
        private string name;  // initializing GrdeBook name

       /* public string Name
        {
            get; 
            private set;
        }*/


        private List<double> grades; // to store grades
        public Book(string name) //constructor
        {
            grades = new List<double>();
            Name = name;
        }
        public void AddGrade(double grade) //method to add grades in List
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
                //Console.WriteLine("Invalid Value");
            }

        }

        public Statistics GetStatistics() //Calculating results, returning object(Statitics)
        {
            var result = new Statistics(); //creating new instance of a class (where variables are initailized)
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            
            foreach(var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }
                result.Average = result.Average / grades.Count; 

                switch (result.Average)
                {   
                    case var d when d >= 90.0:
                        result.Letter = 'A';
                        break;

                    case var d when d >= 80.0:
                        result.Letter = 'B';
                        break;

                    case var d when d >= 70.0:
                        result.Letter = 'C';
                        break;

                    case var d when d >= 60.0:
                        result.Letter = 'D';
                        break;  

                    default:
                        result.Letter = 'F';
                        break;
                }

                return result;

        }
    }
}