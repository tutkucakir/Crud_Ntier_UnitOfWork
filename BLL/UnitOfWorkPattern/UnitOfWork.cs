using BLL.RepositoryImplementation;
using BLL.RepositoryInterfaces;
using BLL.SingletonPattern;
using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        private StudentRepository _studentRepository;

        public UnitOfWork()
        {
            _context = Tools.DbInstance;
        }


        public IStudentRepository Students => _studentRepository = _studentRepository ?? new StudentRepository();

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
