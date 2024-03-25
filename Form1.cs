using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Assignment_final
{
    public partial class Form1 : Form
    {
        ArrayList Cardetails = new ArrayList();

        private int y = -1;
       
        //the above assignment of y (global variable) is used for the arrayList index in the addToListbox() method


        public class CarDetails
        {


            public CarDetails() { }
            //the statement above shows a default constructor
           
            public string InventoryNum { get; set; }
            public string CarName { get; set; }
            public string Carmodel { get; set; }
            public int Year { get; set; }

            public int Mileage { get; set; }
            public int Price { get; set; }


            

            public CarDetails(string a, string b, string c, int d, int e, int f)
            {


                InventoryNum = a;
                CarName = b;
                Carmodel = c;
                Year = d;
                Mileage = e;
                Price = f;

            }
            //the statement above shows class constructor


        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // button
        {
            if ((System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]")) || ((System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "[^0-9]"))) || ((System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "[^0-9]"))))

                // this statement above checks the contents of Mileage,Year and Price , if any of those dont contain only numbers then an error will be displayed
            {
                MessageBox.Show("One or more values for Year/Mileage/Price is not numerical", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
            {

                CarDetails car = new CarDetails(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text));




                Cardetails.Add(car);



                AddToListbox();






            }

        }

       private void button2_Click(object sender, EventArgs e)
        {

            if (listBox1.Items.Count == 0) //this calculates the number of objects in the listbox, if there isn't any, then when you press the remove button an error will be displayed
            {

                MessageBox.Show("Cannot Remove Car When Listbox is Empty", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program was developed by: Ayanda Mthombeni" +
             Environment.NewLine + "Date: 08 April 2020", " About MotorHub Inventory App",
              MessageBoxButtons.OK);
        }

       private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to quit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();

            }

        }


        public void AddToListbox() //Method for updating ListBox

        {
            y++; // each and every time this method is called the variable y(global variable) increases by 1(increment) , which will be accessed by the arraylist index inside the method


            {



                CarDetails car = new CarDetails();





                listBox1.Items.Add(((CarDetails)Cardetails[y]).InventoryNum); // Inventory number added to the listbox

               
    



            }


        }

        private void listBox1_Click(object sender, EventArgs e)
        {
           

            CarDetails car = new CarDetails();


            textBox1.Text = ((CarDetails)Cardetails[listBox1.SelectedIndex]).InventoryNum;
            textBox2.Text = ((CarDetails)Cardetails[listBox1.SelectedIndex]).CarName;
            textBox3.Text = ((CarDetails)Cardetails[listBox1.SelectedIndex]).Carmodel;

            textBox4.Text = ((CarDetails)Cardetails[listBox1.SelectedIndex]).Year.ToString();
            textBox5.Text = ((CarDetails)Cardetails[listBox1.SelectedIndex]).Mileage.ToString();

            textBox6.Text = ((CarDetails)Cardetails[listBox1.SelectedIndex]).Price.ToString();


           
        }


    }
}
