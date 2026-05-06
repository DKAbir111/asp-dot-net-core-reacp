using BookStore.Data.Interfaces;
using BookStore.Data.Models;
using BookStoreAPI.Controllers;
using Moq;
using System;
using Xunit;

namespace XUnitTestProject3
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var mockBookRepo = new Mock<IBookRepository>();
            var bookID = 2;
            var title = "abc";
            mockBookRepo.Setup(x => x.GetBook(It.IsAny<int>())).Returns(new Book() { Id = 2, Title = "abc" });
            var controller = new BooksController(mockBookRepo.Object);

            //Act
            var response = controller.GetBook(bookID);

            //Assert
            Assert.Equal(bookID, response.Value.Id);
            Assert.Equal(title, response.Value.Title);
        }
    }
}
