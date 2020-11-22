using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business
{
    public class Logic : ILogic
    {
        public string HighlightTerms(string joke, string searchTerm)
        {
            var result = Regex.Replace(joke, searchTerm, searchTerm.ToUpper(), RegexOptions.IgnoreCase);
            return result;

        }
    }
}
