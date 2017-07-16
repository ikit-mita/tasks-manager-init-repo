using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TasksManager.Entities
{
    public class Task : DomainObject
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(4096)]
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? CompleteDate { get; set; }

        public TaskStatus Status { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<TagsInTask> Tags { get; set; }
    }
}
