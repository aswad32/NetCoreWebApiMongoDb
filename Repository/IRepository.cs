using System;
using System.Linq;
using System.Linq.Expressions;

namespace BlogReaderApi.Repository
{
    public interface IRepository
    {
        TEntity Single<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class, new();
		IQueryable<TEntity> All<TEntity>(int page, int pageSize) where TEntity : class, new();
    }
}