using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;
        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
        }
		void Numberclick(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string pressed = button.Text;

			if (this.resultText.Text == "0" || currentState < 0)
			{
				this.resultText.Text = "";
				if (currentState < 0)
					currentState *= -1;
			}

			this.resultText.Text += pressed;

			double number;
			if (double.TryParse(this.resultText.Text, out number))
			{
				this.resultText.Text = number.ToString("N0");
				if (currentState == 1)
				{
					firstNumber = number;
				}
				else
				{
					secondNumber = number;
				}
			}

		}

		void OnDelete(object sender, EventArgs e)
		{
			String olds = this.resultText.Text;
			String news = olds.Remove(olds.Length - 1, 1);
			this.resultText.Text = news;
			double delchar = Convert.ToDouble(news);
			if (currentState == 1)
			{
				firstNumber = delchar;
			}
			else
			{
				secondNumber = delchar;
			}
		}
		void Changesign(object sender, EventArgs e)
		{
			String prevs = this.resultText.Text;
			String lates = "-" + prevs;
			double signch = Convert.ToDouble(lates);
			this.resultText.Text = lates;
			if (currentState == 1)
			{
				firstNumber = signch;
			}
			else
			{
				secondNumber = signch;
			}
		}

		void OnSelectOperator(object sender, EventArgs e)
		{
			currentState = -2;
			Button button = (Button)sender;
			string pressed = button.Text;
			this.resultText.Text = pressed;
			mathOperator = pressed;
		}


		void Decimalclick(object sender, EventArgs e)
		{
			String decnum = this.resultText.Text;
			String decnuml = decnum + ".";
			this.resultText.Text = decnuml;
			double decnumll = Convert.ToDouble(decnuml);
			if (currentState == 1)
			{
				firstNumber = decnumll;
			}
			else
			{
				secondNumber = decnumll;
			}

		}
		void Persentage(object sender, EventArgs e)
		{
			String pernum = this.resultText.Text;
			double pernuml = Convert.ToDouble(pernum);
			pernuml = pernuml / 100;
			String pernumll = pernuml.ToString();
			this.resultText.Text = pernumll;

		}


		void OnClear(object sender, EventArgs e)
		{
			firstNumber = 0;
			secondNumber = 0;
			currentState = 1;
			this.resultText.Text = "0";
		}

		void OnCalculate(object sender, EventArgs e)
		{
			if (currentState == 2)
			{
				double result = 0;

				switch (mathOperator)
				{
					case "÷":
						result = (double)(firstNumber / secondNumber);
						break;
					case "×":
						result = (double)(firstNumber * secondNumber);
						break;
					case "+":
						result = (double)(firstNumber + secondNumber);
						break;
					case "-":
						result = (double)(firstNumber - secondNumber);
						break;
					case "%":
						result = (double)(firstNumber / 100.0);
						break;
				}
				this.resultText.Text = result.ToString();
				firstNumber = result;
				currentState = -1;
			}
		}

	}
}
