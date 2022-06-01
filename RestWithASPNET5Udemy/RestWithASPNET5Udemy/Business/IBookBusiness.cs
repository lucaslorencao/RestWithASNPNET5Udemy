using RestWithASPNET5Udemy.Model;
using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book FindByID(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
    }
}
