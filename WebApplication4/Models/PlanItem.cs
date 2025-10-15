using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class PlanItem
    {
       public int Id { get; set; }
       public string Title { get; set; }
       public List<TodoItem> TodoItems { get; set; }
    }
}