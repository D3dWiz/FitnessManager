namespace FitnessManager.Model
{
    public class MemberInfo
    {
        private int memberInfoId;
        private string firstName;
        private string secondName;
        private string thirdName;
        private int age;

        public int MemberInfoId
        {
            get { return memberInfoId; }
            set { memberInfoId = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }

        public string ThirdName
        {
            get { return thirdName; }
            set { thirdName = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
}