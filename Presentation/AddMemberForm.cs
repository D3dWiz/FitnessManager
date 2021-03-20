using System;
using System.Windows.Forms;

namespace NEW_DESIGH
{
    public partial class AddMemberForm : Form
    {
        public AddMemberForm()
        {
            InitializeComponent();
        }

        private Form1 mainForm;

        public bool add = false;
        public string firstName = "", secondName = "", thirdName = "", subscribtionPeriod = "";
        public double cardPrice = 0.00;
        public int age = 0;
        public DateTime period;

        private void AddMemberForm_Load(object sender, EventArgs e)
        {
            mainForm = new Form1();
        }

        /// <summary>
        /// Finalize the membership & add the new member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("You haven't entered first name!");
            }
            else if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("You haven't entered second name!");
            }
            else if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("You haven't entered third name!");
            }
            else if (textBox4.Text == string.Empty)
            {
                MessageBox.Show("You haven't entered age!");
            }
            else if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("You haven't entered subscription period!");
            }
            else if (textBox1.Text.Length < 2 || textBox1.Text.Length > 16)
            {
                MessageBox.Show("The first name value is incorrect!", "Warning!");
            }
            else if (textBox2.Text.Length < 2 || textBox2.Text.Length > 16)
            {
                MessageBox.Show("The first name value is incorrect!", "Warning!");
            }
            else if (textBox3.Text.Length < 2 || textBox3.Text.Length > 16)
            {
                MessageBox.Show("The first name value is incorrect!", "Warning!");
            }
            else if (int.Parse(textBox4.Text) < 4 || int.Parse(textBox4.Text) > 100)
            {
                MessageBox.Show("The age value is incorrect!", "Warning!");
            }
            else
            {
                add = true;
                firstName = textBox1.Text;
                secondName = textBox2.Text;
                thirdName = textBox3.Text;
                age = int.Parse(this.textBox4.Text);

                period = DateTime.Now;
                subscribtionPeriod = listBox1.SelectedItem.ToString();

                switch (listBox1.SelectedIndex)
                {
                    case 0: period = period.AddMonths(1); cardPrice = 50.00; break;
                    case 1: period = period.AddMonths(3); cardPrice = 120.00; break;
                    case 2: period = period.AddMonths(6); cardPrice = 250.00; break;
                    case 3: period = period.AddYears(1); cardPrice = 500.00; break;
                    case 4: period = period.AddYears(2); cardPrice = 900.00; break;
                }
                ClearForm();
                Visible = false;
            }
        }

        /// <summary>
        /// Close & clear the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ClearForm();
            Visible = false;
        }

        /// <summary>
        /// Clear the form when closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearForm();
        }

        /// <summary>
        /// Clear all textBoxes & disselect the listBox item
        /// </summary>
        private void ClearForm()
        {
            foreach (var tb in this.Controls)
            {
                if (tb is TextBox)
                {
                    ((TextBox)tb).Text = String.Empty;
                }
            }

            listBox1.SelectedItem = null;
        }

        /// <summary>
        /// Validation - allow only digits for the age textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox4.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only alphabetical characters.");
            //    textBox1.Text.Remove(textBox1.Text.Length - 1);
            //}
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only alphabetical characters.");
            //    textBox2.Text.Remove(textBox2.Text.Length - 1);
            //}
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only alphabetical characters.");
            //    textBox3.Text.Remove(textBox3.Text.Length - 1);
            //}
        }
    }
}