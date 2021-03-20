using System;
using System.Windows.Forms;

namespace GetInForm.Presentation
{
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();
        }

        public double cash = 0.00;

        private void button1_Click(object sender, EventArgs e)
        {
            cash = double.Parse(textBox1.Text);

            this.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}