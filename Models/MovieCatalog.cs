using System.Collections.Generic;

namespace Filmography.Models
{
    public class MovieCatalog
    {
        private List<string> _values;

        public MovieCatalog() 
        {
            _values = new List<string>();
        }

        public void Add(string value)
        {
            _values.Add(value);
        }

        public string Get() 
        {
            return string.Join(",", _values.ToArray());
        }

        public List<string> Items { get;set; }
    }
}
