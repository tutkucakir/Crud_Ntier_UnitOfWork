﻿using BLL.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UnitOfWorkPattern
{
    public interface IUnitOfWork:IDisposable
    {
        IStudentRepository Students { get; }

        Task<int> CommitAsync();
    }
}
