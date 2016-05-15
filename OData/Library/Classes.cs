using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreateCompany { get; set; }
        public int Year { get; set; }
        public int AgeRate { get; set; }
    }

    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
