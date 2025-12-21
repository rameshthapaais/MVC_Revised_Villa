using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.Domain.Entities;

namespace Villa.Application.Common.Interface
{
    public interface IVillaRepository
    {
        IEnumerable<Villia> GetAll(Expression<Func<Villia, bool>>? filter = null,string?includeProperties =null);
        IEnumerable<Villia> Get(Expression<Func<Villia, bool>> filter,string? includeProperties = null);

        void Add(Villia entity);
        void Update(Villia entity);

        void Remove(Villia entity);

        void Save();

    }
}
