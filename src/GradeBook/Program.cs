using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Shabiha's GradeBook"); //calling method

            /*book.AddGrade(89.5); //passing parameter to method AddGrade in Class Book
            book.AddGrade(99.5);
            book.AddGrade(79.5);
            book.AddGrade(69.5);
            book.GetStatistics(); */

            //user input
            var done = false;
            while(!done)
            {  
                Console.WriteLine("Enter a grade or 'e' to exit");         
                var input = Console.ReadLine();

                if(input == "e")
                {
                    done = true;
                    continue; //will skip the parsing & jump to while statement
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                } 
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
                
            }

            var stats = book.GetStatistics(); //referring to method from BookTests class (for unit test)
            //book.Name = ""; used only if set is not private from program.cs
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The average grade is {stats.Average, 1}"); //displaying ouput
            Console.WriteLine($"The highest grade is {stats.High, 1}");
            Console.WriteLine($"The lowest grade is {stats.Low, 1}");  
            Console.WriteLine($"The letter grade is {stats.Letter}");
            
        }
    }
}
