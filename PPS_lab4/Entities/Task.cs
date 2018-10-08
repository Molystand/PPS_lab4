namespace PPS_lab4.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

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


        #region Операции

        #region Insert

        public void Insert()
        {
            TaskManager manager = new TaskManager();

            // Есть ли такая запись в БД
            bool entryFound = manager.Task.Find(this.Id) != null;

            if (!entryFound)
            {
                manager.Task.Add(this);
                manager.SaveChanges();
            }
        }

        public static void Insert(Task insEntry)
        {
            if (insEntry != null)
            {
                insEntry.Insert();
            }
        }

        #endregion

        #region Delete

        public void Delete()
        {
            TaskManager manager = new TaskManager();

            // Поиск записи для удаления в базе
            Task entry = manager.Task.Find(this.Id);
            if (entry != null)
            {
                try
                {
                    // Удаляем из БД.
                    manager.Task.Remove(entry);
                    manager.SaveChanges();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.InnerException.Message);
                }
            }
        }

        public static void Delete(Task delEntry)
        {
            if (delEntry != null)
            {
                delEntry.Delete();
            }
        }

        #endregion

        #region Update

        public void Update(Task newEntry)
        {
            if (newEntry != null)
            {
                TaskManager manager = new TaskManager();
                Title = newEntry.Title;
                Description = newEntry.Description;
                Date = newEntry.Date;
                PriorityTitle = newEntry.PriorityTitle;
                ProjectId = newEntry.ProjectId;
                UserId = newEntry.UserId;
                manager.SaveChanges();
            }
        }

        public static void Update(Task updEntry, Task newEntry)
        {
            if (updEntry != null)
            {
                updEntry.Update(newEntry);
            }
        }

        #endregion

        #region Get

        public static IEnumerable<Task> Get()
        {
            TaskManager manager = new TaskManager();
            return manager.Task.ToArray();
        }

        #endregion

        #endregion
    }
}
