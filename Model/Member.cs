using System;

namespace FitnessManager.Model
{
    public class Member
    {
        private MemberDbContext personDbContext = new MemberDbContext();

        public int MemberId { get; set; }

        public MemberInfo MemberInfoId { get; set; }

        public DateTime DateRegistered { get; set; }

        public DateTime DateExpiration { get; set; }
    }
}