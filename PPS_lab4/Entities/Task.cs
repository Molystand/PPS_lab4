namespace PPS_lab4.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class Task
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [Required]
        [StringLength(20)]
        public string PriorityTitle { get; set; }

        public int ProjectId { get; set; }

        public int UserId { get; set; }

        public virtual Account Account { get; set; }

        public virtual Priority Priority { get; set; }

        public virtual Project Project { get; set; }
    }
}
