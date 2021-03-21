using Microsoft.EntityFrameworkCore;

namespace FitnessManager.Model
{
    public class MemberDbContext : DbContext
    {
        private DbSet<MemberInfo> memberInfos;
        private DbSet<Member> members;

        public DbSet<MemberInfo> MemberInfos
        {
            get { return memberInfos; }
            set { memberInfos = value; }
        }

        public DbSet<Member> Members
        {
            get { return members; }
            set { members = value; }
        }

        public MemberDbContext()
        {
            // guarantee that the database will automatically be created
            Database.EnsureCreated();
        }

        /// <summary>
        /// Конфигуриране на контекста
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