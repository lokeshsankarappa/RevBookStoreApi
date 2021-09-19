using BookStoreApi.Data;
using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookStoreContext _Context;

        public BooksRepository(BookStoreContext Context)
        {
              _Context = Context;
        }
        public async Task<List<BookModels>> GetAllBooksAysnc()
        {
            var result = await _Context.Books.Select(x => new BookModels
            {
                Id = x.Id,
                Title = x.Title,
                Discription = x.Discription
            }).ToListAsync();
            return result;
        }
        public async Task<BookModels> GetBookByIdAsync(int BookId)
        {
            var result = await _Context.Books.Where(x => x.Id == BookId).Select(x => new BookModels
            {
                Id = x.Id,
                Title = x.Title,
                Discription = x.Discription
            }).FirstOrDefaultAsync();
            return result;
        }
        public async Task<int> AddBookAsync(BookModels bookModels)
        {
            var book = new Books()
            {
                Title = bookModels.Title,
                Discription = bookModels.Discription

            };
            _Context.Books.Add(book);
            await _Context.SaveChangesAsync();
            return book.Id;
        }
        public async Task UpdateBookAsync(int Bookid, BookModels bookModels)
        {
            var book =await  _Context.Books.FindAsync(Bookid);
            if (book != null)
            {
                book.Title = bookModels.Title;
                book.Discription = bookModels.Discription;

                await _Context.SaveChangesAsync();

            }
          
        }

    }
}
