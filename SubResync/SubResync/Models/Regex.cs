using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;


namespace SubResync.Models
{
    public class SubRegex : IRegex
    {

        private static string _RegexToUse = @"(\d+:\d+:\d+,\d+)\s+--\>\s+(\d+:\d+:\d+,\d+)";


        public Regex RegexToUse { get => new(_RegexToUse); }


    }
}




