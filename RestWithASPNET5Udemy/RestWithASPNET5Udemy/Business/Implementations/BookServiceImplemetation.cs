using RestWithASPNET5Udemy.Model;
using System.Threading;
using System.Collections.Generic;
using RestWithASPNET5Udemy.Model.Context;
using System.Linq;
using System;
using RestWithASPNET5Udemy.Repository;

namespace RestWithASPNET5Udemy.Business.Implementations
{
    public class BookBusinessImplemetation : IBookBusiness
    {
        private readonly IBookRepository _repository;

        public BookBusinessImplemetation(IBookRepository repository)
        {
            _repository = repository;
        }
        public List<Book> FindAll()
        {

            return _repository.FindAll();
        }

        public Book FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
