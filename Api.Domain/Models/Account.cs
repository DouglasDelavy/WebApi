using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Domain.Models
{
    [Table("account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Guid { get; set; }
        public string UserName { get; set; }
    }
}
