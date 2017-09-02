using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ef.Data
{
    public class MainTable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubTable> SubTables { get; set; }
    }
}