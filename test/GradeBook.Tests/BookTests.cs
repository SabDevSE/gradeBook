using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var book = new Book(""); //calling method
            book.AddGrade(89.5); 
            book.AddGrade(99.5);
            book.AddGrade(79.5);
            book.AddGrade(69.5);

            //act
            var result = book.GetStatistics(); //calling method & storing ans in result

            //assert (to verify all ans)
            Assert.Equal(84.5, result.Average); 
            Assert.Equal(99.5, result.High);
            Assert.Equal(69.5, result.Low);
            Assert.Equal('B', result.Letter);


        }
    }
}
