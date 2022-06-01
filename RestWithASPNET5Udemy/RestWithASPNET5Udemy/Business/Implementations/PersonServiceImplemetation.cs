﻿using RestWithASPNET5Udemy.Model;
using System.Threading;
using System.Collections.Generic;
using RestWithASPNET5Udemy.Model.Context;
using System.Linq;
using System;
using RestWithASPNET5Udemy.Repository;

namespace RestWithASPNET5Udemy.Business.Implementations
{
    public class PersonBusinessImplemetation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        public PersonBusinessImplemetation(IPersonRepository repository)
        {
            _repository = repository;
        }
        public List<Person> FindAll()
        {

            return _repository.FindAll();
        }

        public Person FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
