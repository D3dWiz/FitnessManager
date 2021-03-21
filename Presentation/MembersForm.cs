using FitnessManager.Model;
using System;
using System.Windows.Forms;

namespace FitnessManager.Presentation
{
    public partial class MembersForm : Form
    {
        private MemberDbContext PersonDbContext = new MemberDbContext();

        private void Members_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        public MembersForm()
        {
            InitializeComponent();
            UpdateMembers();
        }

        /// <summary>
        /// Search member by card id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int cardId = int.Parse(textBox1.Text);
            Member member = PersonDbContext.Members.Find(cardId);

            if (member != null)
            {
                listBox4.SelectedIndex = cardId - 1;
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
            foreach (var member in PersonDbContext.MemberInfos)
            {
                string id = $"{member.MemberInfoId}";
                string fullName = $"{member.FirstName} {member.SecondName} {member.ThirdName}";

                string line = $"{id}{new String(' ', 14 - id.Length)}{fullName}{new String(' ', 57 - fullName.Length)}";
                listBox4.Items.Add(line);
            }
            int index = 0;
            foreach (var member in PersonDbContext.Members)
            {
                string daysLeft = $"{(member.DateExpiration - DateTime.Now).Days}";
                listBox4.Items[index] += daysLeft;
                index++;
            }
        }

        /// <summary>
        /// Validate the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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