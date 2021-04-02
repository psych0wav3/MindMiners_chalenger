using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SubResync.Repositories;

namespace SubResync.Services
{
    public interface ISubResyncService
    {
        public bool ApplyOffset(string pathToFile, double offset);
    }
}
