using BookStoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Repository
{
   public interface IBooksRepository
    {
        Task<List<BookModels>> GetAllBooksAysnc();
        Task<BookModels> GetBookByIdAsync(int BookId);
        Task<int> AddBookAsync(BookModels bookModels);
        Task UpdateBookAsync(int Bookid, BookModels bookModels);

    }
}
   