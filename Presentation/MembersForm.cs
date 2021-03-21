using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FitnessManager.Model;

namespace FitnessManager.Presentation
{
    public partial class MembersForm : Form
    {
        private readonly MemberDbContext PersonDbContext = new MemberDbContext();

        public MembersForm()
        {
            InitializeComponent();
            UpdateMembers();
        }

        private void Members_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        /// <summary>
        ///     Search member by card id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var cardId = int.Parse(textBox1.Text);
            var member = PersonDbContext.Members.Find(cardId);

            if (member != null)
                listBox4.SelectedIndex = cardId - 1;
            else
                MessageBox.Show($"В базата данни не конфигурира карта с ид: {textBox1.Text}");

            textBox1.Text = "";
        }

        /// <summary>
        ///     Update the list when a new member is added
        /// </summary>
        public void UpdateMembers()
        {
            foreach (var member in PersonDbContext.MemberInfos)
            {
                var id = $"{member.MemberInfoId}";
                var fullName = $"{member.FirstName} {member.SecondName} {member.ThirdName}";

                var line = $"{id}{new string(' ', 14 - id.Length)}{fullName}{new string(' ', 57 - fullName.Length)}";
                listBox4.Items.Add(line);
            }

            var index = 0;
            foreach (var member in PersonDbContext.Members)
            {
                var daysLeft = $"{(member.DateExpiration - DateTime.Now).Days}";
                listBox4.Items[index] += daysLeft;
                index++;
            }
        }

        /// <summary>
        ///     Validate the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox1.Clear();
            }
        }
    }
}