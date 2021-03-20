using System;

namespace NEW_DESIGH.Model
{
    public class Member
    {
        private int memberId;
        private MemberInfo memberInfoId;
        private DateTime dateRegistrated;
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

        public DateTime DateRegistrated
        {
            get { return dateRegistrated; }
            set { dateRegistrated = value; }
        }

        public DateTime DateExpiration
        {
            get { return dateExpiration; }
            set { dateExpiration = value; }
        }

        private MemberDbContext personDbContext = new MemberDbContext();
    }
}