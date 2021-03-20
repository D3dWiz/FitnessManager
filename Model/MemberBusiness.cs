using System.Collections.Generic;
using System.Linq;

namespace NEW_DESIGH.Model
{
    class MemberBusiness
    {
        private MemberDbContext personDbContext;

        public List<Member> GetAll()
        {
            using (personDbContext = new MemberDbContext())
            {
                return personDbContext.Members.ToList();
            }
        }

        public Member Get(int id)
        {
            using (personDbContext = new MemberDbContext())
            {
                return personDbContext.Members.Find(id);
            }
        }

        public void Add(Member member)
        {
            using (personDbContext = new MemberDbContext())
            {
                personDbContext.Members.Add(member);
                personDbContext.SaveChanges();
            }
        }

        public void Update(Member member)
        {
            using (personDbContext = new MemberDbContext())
            {
                var item = personDbContext.Members.Find(member.MemberId);
                if (item != null)
                {
                    personDbContext.Entry(item).CurrentValues.SetValues(member);
                    personDbContext.SaveChanges();
                }
            }
        }
    }
}
