using System;
using BookStore.Data.Models;

namespace BookStore.Data.Interfaces
{
	public interface IBookRepository
	{
		List<Books> GetBooks();
		Books GetBook(int id);

	}
}

