using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SubResync.Models
{
    public interface IRegex
    {
        public Regex RegexToUse { get; }
    }
}
