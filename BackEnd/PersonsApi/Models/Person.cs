using System;
using System.Collections.Generic;

namespace PersonsApi.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Mail { get; set; }
    }
}
