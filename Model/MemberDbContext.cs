using Microsoft.EntityFrameworkCore;

namespace FitnessManager.Model
{
    public class MemberDbContext : DbContext
    {
        public MemberDbContext()
        {
            // guarantee that the database will automatically be created
            Database.EnsureCreated();
        }

        public DbSet<MemberInfo> MemberInfos { get; set; }

        public DbSet<Member> Members { get; set; }

        /// <summary>
        ///     Конфигуриране на контекста
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
            (
                "Server=(localdb)\\MSSQLLocalDB;" +
                "Database=Members;" +
                "Integrated Security=true"
            );
        }
    }
}