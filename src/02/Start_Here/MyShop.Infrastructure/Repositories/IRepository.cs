﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyShop.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        // ways to communicate with the repository - consumer doesn't need to know the underlying structure
        T Add(T entity);
        T Update(T entity);
        T Get(Guid id);
        IEnumerable<T> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void SaveChanges();
    }
}
