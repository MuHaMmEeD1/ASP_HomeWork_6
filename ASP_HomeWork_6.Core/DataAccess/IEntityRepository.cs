﻿using ASP_HomeWork_6.Core.Abstraction;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HomeWork_6.Core.DataAccess
{
    public interface IEntityRepository<T> where 
        T: class,IEntity,new()
    {

        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetList(Expression<Func<T, bool>> filter =null);    
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);

    }
}
