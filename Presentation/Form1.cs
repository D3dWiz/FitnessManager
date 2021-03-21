using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FitnessManager.Model;

namespace FitnessManager.Presentation
{
    public partial class Form1 : Form
    {
        private AddMemberForm AddMemberForm;
        private bool choosedItem = true;

        public MemberDbContext memberDbContext = new MemberDbContext();
        private MembersForm MembersForm;

        private PaymentForm PaymentForm;
        private double price, currentPrice, totalPrice, cashMoney;
        private int quantity = 1;
        private string subscribtionPeriod = "";

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Configure the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel2.Visible = true;

            AddMemberForm = new AddMemberForm();
            MembersForm = new MembersForm();
            PaymentForm = new PaymentForm();

            textBox1.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;

            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;

            MembersForm.StartPosition = new FormStartPosition();
            MembersForm.Location = new Point(Location.X, Location.Y + 47);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        /// <summary>
        ///     Configure the form when button1 is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            MembersForm.Visible = false;
            panel4.Visible = false;
            panel2.Visible = true;
        }

        /// <summary>
        ///     Minimize the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            MembersForm.WindowState = FormWindowState.Minimized;
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        ///     Exit the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        ///     Configure the list and show selected products in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = comboBox1.SelectedIndex;
            var selectedProduct = comboBox1.Items[index].ToString();
            if (choosedItem)
            {
                listBox1.Items.Add(selectedProduct);
                listBox3.Items.Add("x 1");
                comboBox1.Text = "Products";
                textBox1.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                choosedItem = false;

                if (index == 0) price = 1.00;
                if (index == 1) price = 2.00;
                if (index == 2) price = 4.00;

                currentPrice = price * quantity;
            }
        }

        /// <summary>
        ///     Add item to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            totalPrice += currentPrice;
            label4.Text = $"$ {totalPrice:f2}";

            listBox2.Items.Add(listBox1.Items[0]);
            listBox4.Items.Add(listBox3.Items[0]);
            listBox5.Items.Add($"$ {currentPrice:f2}");

            listBox1.Items.Clear();
            listBox3.Items.Clear();

            textBox1.PlaceholderText = "Enter quantity:";
            button5.Enabled = false;
            button6.Enabled = false;
            choosedItem = true;

            quantity = 1;
            price = 0.00;

            button9.Enabled = true;
            button11.Enabled = true;

            textBox1.Clear();
        }

        /// <summary>
        ///     Remove the selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.Items != null)
            {
                listBox1.Items.Clear();
                listBox3.Items.Clear();
                //textBox1.Text = "";
                textBox1.PlaceholderText = "Enter quantity:";
                textBox1.Enabled = false;
                choosedItem = true;
                button5.Enabled = false;
                button6.Enabled = false;
                quantity = 1;
                price = 0.00;

                //int index = comboBox1.SelectedIndex;
                //comboBox1.Items[index] = "Products";
                textBox1.Clear();
            }
        }

        /// <summary>
        ///     Add training to the pre add list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            if (choosedItem)
            {
                listBox1.Items.Add("training");
                listBox3.Items.Add("x 1");
                comboBox1.Text = "Products";
                textBox1.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                choosedItem = false;

                price = 3.00;
                currentPrice = price * quantity;
            }
        }

        /// <summary>
        ///     Clear the prices & added items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();

            label4.Text = "$ 0.00";
            label5.Text = "$ 0.00";
            label6.Text = "$ 0.00";

            currentPrice = 0.00;
            totalPrice = 0.00;
            cashMoney = 0.00;

            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
        }

        /// <summary>
        ///     Open Members form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            MembersForm.Visible = true;
            panel4.Visible = true;
            panel2.Visible = false;
        }

        /// <summary>
        ///     Open the form to fill the new member information (member)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            AddMemberForm.ShowDialog();

            if (AddMemberForm.add)
            {
                button9.Enabled = true;
                button11.Enabled = true;

                subscribtionPeriod = AddMemberForm.subscribtionPeriod;
                price = AddMemberForm.cardPrice;
                totalPrice += price;
                label4.Text = $"$ {totalPrice:f2}";

                listBox2.Items.Add($"{subscribtionPeriod} subscribtion");
                listBox4.Items.Add("x 1");
                listBox5.Items.Add($"$ {price:f2}");
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Validate the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // validation - enter only numbers
            if (Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }

            if (!choosedItem)
            {
                quantity = int.Parse(textBox1.Text);
                currentPrice = price * quantity;

                listBox3.Items.Clear();
                listBox3.Items.Add($"x {textBox1.Text}");
            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Open the PaymentForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            PaymentForm.ShowDialog();
            if (PaymentForm.madePayment)
            {
                cashMoney += PaymentForm.cash;
                if (cashMoney < totalPrice)
                {
                    label5.Text = $"$ {cashMoney:f2}";
                    MessageBox.Show($"You need $ {Math.Abs(cashMoney - totalPrice):f2}, to complete the order!", "Not enough money!");
                }
                else
                {
                    label5.Text = $"$ {cashMoney:f2}";
                    label6.Text = $"$ {cashMoney - totalPrice:f2}";

                    button9.Enabled = false;
                    button10.Enabled = true;
                }
            }
        }

        /// <summary>
        ///     Complete payment & if subscribtion is bought add the member to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            if (AddMemberForm.add)
            {
                subscribtionPeriod = AddMemberForm.subscribtionPeriod;

                var memberInfo = new MemberInfo();
                memberInfo.FirstName = AddMemberForm.firstName;
                memberInfo.SecondName = AddMemberForm.secondName;
                memberInfo.ThirdName = AddMemberForm.thirdName;
                memberInfo.Age = AddMemberForm.age;

                memberDbContext.MemberInfos.Add(memberInfo);

                memberDbContext.Members.Add(
                    new Member
                    {
                        //Id = 0,
                        MemberInfoId = memberInfo,
                        DateRegistered = DateTime.Now,
                        DateExpiration = AddMemberForm.period
                    }
                );

                memberDbContext.SaveChanges();

                MembersForm.UpdateMembers();
                cashMoney = 0;
            }

            listBox2.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();

            label4.Text = "$ 0.00";
            label5.Text = "$ 0.00";
            label6.Text = "$ 0.00";

            currentPrice = 0.00;
            totalPrice = 0.00;
            cashMoney = 0.00;

            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}