using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = await _context.Books.Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
            }).ToListAsync();

            return records;
        }
        public async Task<BookModel> GetOneBooksAsync(int bookId)
        {
            var records = await _context.Books.Where(x => x.Id == bookId).Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
            }).FirstOrDefaultAsync();

            return records;
        }

        public async Task<string> AddNewBookAsync(BookModel model)
        {
            var book = new Books()
            {
                Title = model.Title,
                Description = model.Description,
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return "Added book Completely";
        }
    }
}
