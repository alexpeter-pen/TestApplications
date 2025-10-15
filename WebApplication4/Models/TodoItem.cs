using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [ForeignKey(nameof(PlanItem))]
        public int PlanItemId { get; set; }

        public PlanItem PlanItem { get; set; }
    }
}