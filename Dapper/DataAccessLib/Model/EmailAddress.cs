using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLib.Model
{
    public class EmailAddress
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int PersonId { get; set; }
    }
}
