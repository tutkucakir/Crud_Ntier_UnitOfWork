﻿using MODEL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.RepositoryPattern
{
    public interface IRepository<T> where T : class
    {
        List<T> SelectAll();
        List<T> SearchList(Expression<Func<T, bool>> predicate);
        T SelectById(int Id);
        T SearchEntity(Expression<Func<T, bool>> predicate);
        ResultModel<T> Insert(T item);
        ResultModel<T> Update(T item);
        ResultModel<bool> Delete(int Id);
    }
}
