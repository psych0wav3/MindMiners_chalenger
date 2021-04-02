using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubResync.Repositories
{
    public interface ISubResyncRepository
    {
        public bool IsAStrFile(string pathToFile);
        public bool InsertOffset(string pathToFile, double offset);
        public string TimeShiftAdjustment(double offset, string timeString);
    };
}
