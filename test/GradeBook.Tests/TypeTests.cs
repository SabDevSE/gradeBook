using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {

        public void StringsBehavesLikeValueTypes()
        {
            string name = "Scott";
            var upper = MakeUpperCase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }
        
        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(x);

            Assert.Equal(3, x);
        }

        private void SetInt(int x)
        {
            x = 42;
        }
        private int GetInt()
        {
            return 3;
        } //the ans will remain 3 as it is pass by value. if change it by ref we will get the ans 42

        [Fact]
        public void CSarpIsPassByValue()
        {
            //invoke a method that will instantiate a book
            var book1 = GetBook("Book1"); 
            GetBookSetName(book1, "NewName");

            Assert.Equal("Book1", book1.Name);
            
        }

        public void GetBookSetName(Book book, string name) //placing the copy of book1 in book
        {
            book = new Book(name); //but as we created a new obj it wont point to book1 object. 
            book.Name = name;           //the book name will be "New Name" 
        }                               //the book name will change to "Book1" only if we PassByRef


        [Fact]
        public void CanSetNameFromReference()
        {
            //invoke a method that will instantiate a book
            var book1 = GetBook("Book1"); 
            SetName(book1, "NewName");

            Assert.Equal("NewName", book1.Name);
            
        }

        public void SetName(Book book, string name) //the value of book1 is placed in book
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //invoke a method that will instantiate a book
            var book1 = GetBook("Book1"); 
            var book2 = GetBook("Book2");

            Assert.NotSame(book1, book2);
            
        }

        public void TwoVarsCanReferSameObject()
        {
            //invoke a method that will instantiate a book
            var book1 = GetBook("Book1");
            var book2 = book1; //not making a copy instead storing a copy of value of book1 in book2

            Assert.Same(book1, book2);

        }

        Book GetBook(string name) //returning Book 
        {
            return new Book(name);
        }
    }
}
