using Microsoft.EntityFrameworkCore;

namespace ViewRecordProject.Data
{
    public class dataContext : DbContext
    {
        public dataContext(DbContextOptions<dataContext> options)
            : base(options)
        {
        }

        //public DbSet<ViewRecordProject.Models.Students> Students { get; set; }
        public DbSet<ViewRecordProject.Models.monthlyFee> monthlyFee{ get; set; }
        public DbSet<ViewRecordProject.Models.Faculty> Faculties{ get; set; }
        public DbSet<ViewRecordProject.Models.Login> Login2 { get; set; }
        public DbSet<ViewRecordProject.Models.Student> Student { get; set; }
        public DbSet<ViewRecordProject.Models.ClassInfo> ClassInfo { get; set; }
        public DbSet<ViewRecordProject.Models.Section> Section { get; set; }
        public DbSet<ViewRecordProject.Models.StudentInClass> StudentInClass { get; set; }
        public DbSet<ViewRecordProject.Models.Payment> Payment { get; set; }


    }
}
