using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ef.Data
{
    public class SubTable
    {
        [Key]
        public int Id { get; set; }
        public int MainTableId { get; set; }
        public string Name { get; set; }

        [ForeignKey("MainTableId")]
        public virtual MainTable MainTable { get; set; }
    }
}