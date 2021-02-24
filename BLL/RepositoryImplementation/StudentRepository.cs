using BLL.RepositoryInterfaces;
using BLL.RepositoryPattern;
using MODEL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.RepositoryImplementation
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
    }
}
