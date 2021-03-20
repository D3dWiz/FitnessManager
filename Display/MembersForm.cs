using GetInForm.Model;
using System;
using System.Windows.Forms;

namespace GetInForm.Display
{
    public partial class MembersForm : Form
    {
        // private MemberBusiness MemberBusiness = new MemberBusiness();
        private MemberDbContext PersonDbContext = new MemberDbContext();

        private void Members_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        public MembersForm()
        {
            InitializeComponent();
            foreach (var member in PersonDbContext.MemberInfos)
            {
                listBox1.Items.Add($"{member.MemberInfoId}");
                listBox3.Items.Add($"{member.FirstName} {member.SecondName} {member.ThirdName}");
            }
            foreach (var member in PersonDbContext.Members)
            {
                listBox2.Items.Add($"{(member.DateExpiration - DateTime.Now).Days}");
            }
        }

        /// <summary>
        /// Search member by card id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //TODO fix bug
            int cardId = int.Parse(textBox1.Text);
            Member member = PersonDbContext.Members.Find(cardId);

            if (member != null)
            {
                listBox1.SelectedIndex = cardId;
                listBox2.SelectedIndex = cardId;
                listBox3.SelectedIndex = cardId;
            }
            else
            {
                MessageBox.Show($"В базата данни не конфигурира карта с ид: {textBox1.Text}");
            }

            textBox1.Text = "";
        }

        /// <summary>
        /// Update the list when a new member is added
        /// </summary>
        public void UpdateMembers()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            foreach (var member in PersonDbContext.MemberInfos)
            {
                listBox1.Items.Add($"{member.MemberInfoId}");
                listBox3.Items.Add($"{member.FirstName} {member.SecondName} {member.ThirdName}");
            }
            foreach (var member in PersonDbContext.Members)
            {
                listBox2.Items.Add($"{(member.DateExpiration - DateTime.Now).Days}");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox1.Clear();
            }
        }
    }
}