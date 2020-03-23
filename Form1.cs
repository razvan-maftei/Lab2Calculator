using System;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form {
        private Double currentNumber = 0f;
        private Double previousNumber = 0f;

        private string inputNumber = "0";
        private string history;

        private enum Operator
        {
            ADD,
            SUB,
            MUL,
            DIV,
            PER
        }

        private Operator currentOp = Operator.ADD;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void Btplus_Click(object sender, EventArgs e)
        {
            this.updateCurrentNumber();
            this.inputNumber = "0";
            this.currentOp = Operator.ADD;
            this.history += this.currentNumber + " + ";
        }

        private void Btmin_Click(object sender, EventArgs e)
        {

            this.updateCurrentNumber();
            this.inputNumber = "0";
            this.currentOp = Operator.SUB;
            this.history += this.currentNumber + " - ";
        }

        private void Btmul_Click(object sender, EventArgs e)
        {

            this.updateCurrentNumber();
            this.inputNumber = "0";
            this.currentOp = Operator.MUL;
            this.history += this.currentNumber + " * ";
        }

        private void Btdiv_Click(object sender, EventArgs e)
        {

            this.updateCurrentNumber();
            this.inputNumber = "0";
            this.currentOp = Operator.DIV;
            this.history += this.currentNumber + " / ";
        }

        private void Btpercent_Click(object sender, EventArgs e)
        {

            this.updateCurrentNumber();
            this.inputNumber = "0";
            this.currentOp = Operator.PER;
            this.history += this.currentNumber + " % ";
        }

        private void Bteq_Click(object sender, EventArgs e)
        {
            this.equalize();
        }

        private void equalize()
        {
            this.history += this.currentNumber;
            switch (this.currentOp)
            {
                case Operator.ADD:
                    this.currentNumber = (this.previousNumber + this.currentNumber);
                    break;
                case Operator.SUB:
                    this.currentNumber = (this.previousNumber - this.currentNumber);
                    break;
                case Operator.MUL:
                    this.currentNumber = (this.previousNumber * this.currentNumber);
                    break;
                case Operator.DIV:
                    this.currentNumber = (this.previousNumber / this.currentNumber);
                    break;
                case Operator.PER:
                    this.currentNumber = (this.previousNumber / this.currentNumber) * 100;
                    break;
            }

            this.history += " = " + this.currentNumber;

            this.inputNumber = this.currentNumber.ToString("N");
            this.previousNumber = 0f;
            this.updateDisplayNumber();
            this.history = null;
        }

        public void appendNum(string num)
        {
            if (this.inputNumber == "0")
            {
                this.inputNumber = num;
            }
            else
            {
                this.inputNumber += num;
            }
            this.updateCurrentNumber();
            this.updateDisplayNumber();
        }

        public void addFloatingPoint()
        {
            if (!this.inputNumber.Contains('.'))
            {
                if (this.inputNumber == null || this.inputNumber == "0")
                {
                    this.inputNumber = "0.";
                }
                else
                {
                    this.inputNumber += '.';
                }

                this.updateDisplayNumber();
            }
        }

        public void updateDisplayNumber()
        {
            this.inputfield.Text = this.inputNumber;
            this.eqlabel.Text = this.history;
        }

        public void updateCurrentNumber()
        {
            this.previousNumber = this.currentNumber;
            this.currentNumber = Double.Parse(this.inputNumber);
        }

        private void numberButtonClick(object sender, EventArgs e)
        {
            this.appendNum((sender as Button).Text);
        }

        private void Btdot_Click(object sender, EventArgs e)
        {
            this.addFloatingPoint();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.currentNumber = 0f;
            this.previousNumber = 0f;
            this.inputNumber = "0";
            this.history = null;
            this.updateDisplayNumber();
        }

        private void Inputfield_TextChanged(object sender, EventArgs e)
        {
            this.inputNumber = (sender as TextBox).Text;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Keys.Add))
            {
                this.currentOp = Operator.ADD;
            }
            else if (e.KeyChar.Equals(Keys.Subtract))
            {
                this.currentOp = Operator.SUB;
            }
            else if (e.KeyChar.Equals(Keys.Multiply))
            {
                this.currentOp = Operator.MUL;
            }
            else if (e.KeyChar.Equals(Keys.Divide))
            {
                this.currentOp = Operator.DIV;
            }
            else if (e.KeyChar.Equals(Keys.Enter))
            {
                this.equalize();
            }
        }

        private void Inputfield_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Inputfield_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Btsign_Click(object sender, EventArgs e)
        {
            this.currentNumber = -1 * this.currentNumber;
            if (!this.inputNumber.StartsWith("-"))
            {
                this.inputNumber = this.inputNumber.Insert(0, "-");
            }
            else
            {
                this.inputNumber = this.inputNumber.Substring(1);
            }
            this.updateDisplayNumber();
        }
    }
}
