using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubResync.Models;

namespace SubResync.Repositories
{
    public class SubResyncRepository : ISubResyncRepository
    {
        private readonly IRegex _regex;
        public SubResyncRepository(IRegex regex)
        {
            _regex = regex;
        }
       
        public bool IsAStrFile(string pathTofile)
        {
           if(File.Exists(pathTofile) && pathTofile.IndexOf(".srt", StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                return true;
            }
            return false;
        } 

        public string TimeShiftAdjustment(double offset, string timeString)
        {
            string[] timeRanges = timeString.Split(new string[] { "-->" }, StringSplitOptions.None);
            string[] startTime = timeRanges[0].Split(',');
            string[] endTime = timeRanges[1].Split(',');
            var first = TimeSpan.Parse(startTime[0].Trim());
            var newFirst = first.Add(new TimeSpan(0, 0, (int)offset));
            var second = TimeSpan.Parse(endTime[0].Trim());
            var newSecond = second.Add(new TimeSpan(0, 0, (int)offset));
            var newFirstString = string.Format("{0:D2}:{1:D2}:{2:D2}", newFirst.Hours, newFirst.Minutes, newFirst.Seconds);
            var newSecondString = string.Format("{0:D2}:{1:D2}:{2:D2}", newSecond.Hours, newSecond.Minutes, newSecond.Seconds);
            var adjusted = newFirstString + "," + startTime[1].Trim() + " --> " + newSecondString + "," + endTime[1].Trim();
            return adjusted;
        }

        public bool InsertOffset(string pathToFile, double offset)
        {
            var outputLines = new List<string>();
            string[] lines = File.ReadAllLines(pathToFile, Encoding.UTF8);
            foreach (var line in lines)
            {
                var match = _regex.RegexToUse.Match(line);
                if (match.Success)
                {
                    outputLines.Add(TimeShiftAdjustment(offset, line));
                }
                else
                {
                    outputLines.Add(line);
                }
            }

            File.WriteAllLines(pathToFile, outputLines.ToArray(), Encoding.UTF8);
            
            return true;
            
            
        }
    }
}
