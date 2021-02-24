using BLL.RepositoryPattern;
using MODEL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.RepositoryInterfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
    }
}
