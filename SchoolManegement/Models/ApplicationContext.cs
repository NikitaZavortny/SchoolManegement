using System.Data.Entity;

namespace SchoolManegement.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }

        public ApplicationContext() : base("SMdb")
        { }
    }
}
