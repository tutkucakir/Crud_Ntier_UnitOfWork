using BLL.SingletonPattern;
using DAL.Context;
using MODEL.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.RepositoryPattern
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        internal readonly DataContext _db;

        public BaseRepository()
        {
            _db = Tools.DbInstance;
        }
        public List<T> SelectAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> SearchList(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Where(predicate).ToList();
        }

        public T SearchEntity(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().FirstOrDefault(predicate);
        }

        public T SelectById(int Id)
        {
            return _db.Set<T>().Find(Id);
        }



        public ResultModel<T> Insert(T item)
        {
            ResultModel<T> result = new ResultModel<T>();
            _db.Set<T>().Add(item);
            if (_db.SaveChanges() > 0)
            {
                result.IsSuccess = true;
                result.Message = typeof(T).Name + " Ekleme İşlemi Başarılı";
                result.Data = item;
            }
            else
                result.IsSuccess = false;

            return result;
        }

        public ResultModel<T> Update(T item)
        {
            ResultModel<T> result = new ResultModel<T>();
            _db.Set<T>().Attach(item);
            _db.Entry(item).State = EntityState.Modified;
            if (_db.SaveChanges() > 0)
            {
                result.IsSuccess = true;
                result.Message = typeof(T).Name + " Güncelleme İşlemi Başarılı";
                result.Data = item;
            }
            else
                result.IsSuccess = false;

            return result;
        }

        public virtual ResultModel<bool> Delete(int Id)
        {
            ResultModel<bool> result = new ResultModel<bool>();
            _db.Set<T>().Remove(this.SelectById(Id));
            if (_db.SaveChanges() > 0)
                result.IsSuccess = true;
            else
                result.IsSuccess = false;
            return result;
        }


    }
}
