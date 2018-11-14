using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalcV2
{
    public partial class Form1 : Form
    {

        bool isOperationPerformed = false;
        string operationPerformed = "";
        Double calculation_Result = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Numbers_clicked(object sender, EventArgs e) // All number buttons and decimal
        {
            Button button = (Button)sender;

            if(textBox_Result.Text=="0") { textBox_Result.Clear(); } // If a number has been pressed and the number field is zero then clear the number field.

            if(textBox_Result.Text=="-0") { textBox_Result.Text = "-"; } // If number field is -0 but a whole integer has been pressed, leave the "-" sign on the number field and continue with the rest of the function to add a whole integer.

            if(button.Text == ".")
            {
                if (!textBox_Result.Text.Contains('.')) // Only one decimal allowed
                {
                    textBox_Result.Text = textBox_Result.Text + button.Text;
                }
            } else
            {
                textBox_Result.Text = textBox_Result.Text + button.Text;
            }

         }

        private void OperatorButtonClicked(object sender, EventArgs e) // Buttons + - x ÷ %
        {
            Button button = (Button)sender;
            operationPerformed = button.Text;
            labelOperationPerformed.Text = textBox_Result.Text + " " + button.Text;

 
                if (calculation_Result != 0) // Calculation has been stored, do this.
            {
                isOperationPerformed = true;
                equals.PerformClick();
                
            }
            else
            {
                if ((textBox_Result.Text != "0") && (textBox_Result.Text != ".") && (textBox_Result.Text != "-")) // When operator button is pushed, but numbers have been entered, BUT we didnt start as a negative, then do this. 
                {
                    labelOperationPerformed.Text = textBox_Result.Text + " " + button.Text;
                    calculation_Result = Double.Parse(textBox_Result.Text);
                    textBox_Result.Text = "0";
                    isOperationPerformed = true;
                } else
                {
                    operationPerformed = ""; // When operator button is pushed, but NO numbers have been entered do this. 
                }
            }
        }

        private void button19_Click(object sender, EventArgs e) // Clear results textbox only
        {
            textBox_Result.Text = "0";
        }

        private void button16_Click(object sender, EventArgs e) //Clear equation
        {
 
            isOperationPerformed = false;
            operationPerformed = "";
            textBox_Result.Text = "0";
            labelOperationPerformed.Text = "";
            calculation_Result = 0;
        }

        private void button17_Click(object sender, EventArgs e) //Press equals button
        {
            if (isOperationPerformed)
            {
                switch (operationPerformed)
                {
                    case "+":
                        textBox_Result.Text = (calculation_Result + Double.Parse(textBox_Result.Text)).ToString();
                        break;

                    case "-":
                        textBox_Result.Text = (calculation_Result - Double.Parse(textBox_Result.Text)).ToString();
                        break;

                    case "x":
                        textBox_Result.Text = (calculation_Result * Double.Parse(textBox_Result.Text)).ToString();
                        break;

                    case "÷":
                        textBox_Result.Text = (calculation_Result / Double.Parse(textBox_Result.Text)).ToString();
                        break;

                    default:
                        break;
                }

                calculation_Result = Double.Parse(textBox_Result.Text);
                labelOperationPerformed.Text = "";
                isOperationPerformed = false;


            }
        }

        private void Plus_Minus(object sender, EventArgs e)
        {

            if ((textBox_Result.Text != "0") && (textBox_Result.Text != "-0")) {
                textBox_Result.Text = (-1 * Double.Parse(textBox_Result.Text)).ToString();
            }

            

            if (textBox_Result.Text == "0")
            {
                textBox_Result.Text = "-0";
            }
            else
            {

                if (textBox_Result.Text == "-0")
                {
                    textBox_Result.Text = "0";
                }

            }

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(e.KeyChar.ToString())
            {
                case "0":
                    zero.PerformClick();
                    break;

                case "1":
                    one.PerformClick();
                    break;

                case "2":
                    two.PerformClick();
                    break;

                case "3":
                    three.PerformClick();
                    break;

                case "4":
                    four.PerformClick();
                    break;

                case "5":
                    five.PerformClick();
                    break;

                case "6":
                    six.PerformClick();
                    break;

                case "7":
                    seven.PerformClick();
                    break;

                case "8":
                    eight.PerformClick();
                    break;

                case "9":
                    nine.PerformClick();
                    break;

                case "/":
                    divide.PerformClick();
                    break;

                case "*":
                    multiply.PerformClick();
                    break;

                case "+":
                    plus.PerformClick();
                    break;

                case "=":
                    equals.PerformClick();
                    break;

                default:
                    break;


            }
        }
    }
}
