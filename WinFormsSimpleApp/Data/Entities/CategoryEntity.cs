using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WinFormsSimpleApp.Data.Entities
{
    [Table("tblCategories")]
    public class CategoryEntity
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime DateCreated { get; set; }
        [Required, StringLength(255)]
        public string Title { get; set; }
        [StringLength(200)]
        public string Image { get; set; }
        public int Priority { get; set; }

        [ForeignKey("Parent")]
        public int ? ParentId { get; set; }
        public virtual CategoryEntity Parent { get; set; }
    }
}
