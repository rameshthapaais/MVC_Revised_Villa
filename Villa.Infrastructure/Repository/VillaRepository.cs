using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.Application.Common.Interface;
using Villa.Domain.Entities;
using Villa.Infrastructure.Data;

namespace Villa.Infrastructure.Repository
{
    public class VillaRepository : IVillaRepository
    {
        private readonly ApplicationDbContext _context;

        public VillaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Villia entity)
        {
            _context.Villas.Add(entity);
        }

        public Villia Get(Expression<Func<Villia, bool>> filter, string? includeProperties = null)
        {

            IQueryable<Villia> query = _context.Set<Villia>();
            if (filter != null)
            {
                query = query.Where(filter);


            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();

        }

        public IEnumerable<Villia> GetAll(Expression<Func<Villia, bool>> filter, string? includeProperties = null)
        {

            IQueryable<Villia> query = _context.Set<Villia>();
            if (filter != null)
            {
                query = query.Where(filter);


            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(Villia entity)
        {
            _context.Villas.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();

        }

        public void Update(Villia entity)
        {
            _context.Villas.Update(entity);
        }
    }
}
