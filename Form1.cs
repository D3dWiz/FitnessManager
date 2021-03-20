using System;
using System.Windows.Forms;
using GetInForm.Model;

namespace GetInForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public MemberDbContext memberDbContext = new MemberDbContext();
     //  public ProductDbContext productDbContext = new ProductDbContext();
        PaymentForm PaymentForm;
        AddMemberForm AddMemberForm;
        MembersForm MembersForm;
        bool choosedItem = true;
        int quantity = 1;
        double price = 0.00, currentPrice = 0.00, totalPrice = 0.00;
        string subscribtionPeriod = "";
       

        private void Form1_Load(object sender, EventArgs e)
        {
            AddMemberForm = new AddMemberForm();
            MembersForm = new MembersForm();
            PaymentForm = new PaymentForm();

            // panel4.BackColor = DefaultBackColor;
            textBox1.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;

            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;

            MembersForm.StartPosition = new FormStartPosition();
            MembersForm.Location = new System.Drawing.Point(this.Location.X, this.Location.Y + 47);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MembersForm.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            string selectedProduct = comboBox1.Items[index].ToString();
            if (choosedItem)
            {
                listBox1.Items.Add(selectedProduct);
                listBox3.Items.Add("x 1");
                comboBox1.Text = "Products";
                textBox1.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                choosedItem = false;

                if (index == 0)
                {
                    price = 1.00;
                }
                if (index == 1)
                {
                    price = 2.00;
                }
                if (index == 2)
                {
                    price = 4.00;
                }

                currentPrice = price * quantity;
            }
            
        }
        /// <summary>
        /// Add item to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            totalPrice += currentPrice;
            label4.Text = $"$ {totalPrice}";

            listBox2.Items.Add(listBox1.Items[0]);
            listBox4.Items.Add(listBox3.Items[0]);
            listBox5.Items.Add($"$ {currentPrice}");

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
        /// Remove the selected item 
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
        /// Add training to the pre add list
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
        /// Clear the prices & added items
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

            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
        }

        /// <summary>
        /// Open Members form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            MembersForm.Visible = true;
        }

        /// <summary>
        /// Open the form to fill the new member information (member)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            AddMemberForm.ShowDialog();
            button9.Enabled = true;
            button11.Enabled = true;

            if (AddMemberForm.add)
            {
                price = AddMemberForm.cardPrice;
                totalPrice += price;
                label4.Text = $"$ {totalPrice}";

                listBox2.Items.Add($"{subscribtionPeriod} subscribtion");
                listBox4.Items.Add("x 1");
                listBox5.Items.Add($"$ {price}");
            }
            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // validation - enter only numbers
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
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
        /// Open the PaymentForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            PaymentForm.ShowDialog();
            double cashMoney = PaymentForm.cash;
            label5.Text = $"$ {cashMoney}";
            label6.Text = $"$ {cashMoney - totalPrice}";

            button10.Enabled = true;
        }

        /// <summary>
        /// Complete payment & if subscribtion is bought add the member to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            if (AddMemberForm.add)
            {
                subscribtionPeriod = AddMemberForm.subscribtionPeriod;

                MemberInfo memberInfo = new MemberInfo();
                memberInfo.FirstName = AddMemberForm.firstName;
                memberInfo.SecondName = AddMemberForm.secondName;
                memberInfo.ThirdName = AddMemberForm.thirdName;
                memberInfo.Age = AddMemberForm.age;

                memberDbContext.MemberInfos.Add(memberInfo);

                memberDbContext.Members.Add(
                        new Member()
                        {
                        //Id = 0,
                        MemberInfoId = memberInfo,
                            DateRegistrated = DateTime.Now,
                            DateExpiration = AddMemberForm.period
                        }
                    );

                memberDbContext.SaveChanges();

                MembersForm.UpdateMembers();
            }

            listBox2.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();

            label4.Text = "$ 0.00";
            label5.Text = "$ 0.00";
            label6.Text = "$ 0.00";

            currentPrice = 0.00;
            totalPrice = 0.00;

            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;



            //for (int i = 0; i < listBox4.Items.Count; i++)
            //{
            //    string productSale = listBox2.Items[i].ToString();

            //    string qSale = listBox4.Items[i].ToString();
            //    int quantitySale = int.Parse(qSale.Split(' ')[1].ToString());

            //    string tSale = listBox5.Items[i].ToString();
            //    double totalSale = double.Parse(tSale.Split(' ')[1].ToString());

            //    Sale sale = new Sale();
            //    sale.Product = productSale;
            //    sale.Quantity = quantitySale;
            //    sale.Total = totalSale;

            //    memberDbContext.Sales.Add(sale); 

            //    memberDbContext.SaveChanges();
            //}
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
