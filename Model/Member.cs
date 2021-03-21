using System;

namespace FitnessManager.Model
{
    public class Member
    {
        private int memberId;
        private MemberInfo memberInfoId;
        private DateTime dateRegistered;
        private DateTime dateExpiration;

        public int MemberId
        {
            get { return memberId; }
            set { memberId = value; }
        }

        public MemberInfo MemberInfoId
        {
            get { return memberInfoId; }
            set { memberInfoId = value; }
        }

        public DateTime DateRegistered
        {
            get { return dateRegistered; }
            set { dateRegistered = value; }
        }

        public DateTime DateExpiration
        {
            get { return dateExpiration; }
            set { dateExpiration = value; }
        }

        private MemberDbContext personDbContext = new MemberDbContext();
    }
}