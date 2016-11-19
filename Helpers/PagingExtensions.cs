using System.Linq;

namespace BlogReaderApi.Helpers
{
    public static class PagingExtensions
    {
        public static IQueryable<TSource> Page<TSource>(IQueryable<TSource> source, int page, int pageSize) 
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}