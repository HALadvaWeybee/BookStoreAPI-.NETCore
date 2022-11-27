using BookStoreAPI.Models;

namespace BookStoreAPI.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetOneBooksAsync(int bookId);
        Task<string> AddNewBookAsync(BookModel model);
    }
}
