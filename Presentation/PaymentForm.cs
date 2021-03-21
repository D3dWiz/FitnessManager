using System;
using System.Windows.Forms;

namespace FitnessManager.Presentation
{
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();
        }

        public double cash = 0.00;

        /// <summary>
        /// Confirm payment and reset the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            cash = double.Parse(textBox1.Text);

            this.Visible = false;
            textBox1.Clear();
            label2.Text = $"$ 0:00";
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
            label2.Text = $"$ {cash:f2}";
        }

        /// <summary>
        /// Close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            textBox1.Clear();
            label2.Text = $"$ 0:00";
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
        }
    }
}