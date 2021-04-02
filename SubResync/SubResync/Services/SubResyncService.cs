using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SubResync.Repositories;

namespace SubResync.Services
{
    public class SubResyncService : ISubResyncService
    {
        private ISubResyncRepository _repo;

        public SubResyncService(ISubResyncRepository repo)
        {
            _repo = repo;
        }
        public bool ApplyOffset(string pathToFile, double offset)
        {
            if (_repo.IsAStrFile(pathToFile))
            {
                if(_repo.InsertOffset(pathToFile, offset))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
