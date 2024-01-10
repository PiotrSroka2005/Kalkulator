﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kalkulator
{
    public partial class MainPage : ContentPage
    {
        string currentEntry = "";
        string leftOperand = "";
        string rightOperand = "";
        string operation = "";
        bool operationSelected = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSelectNumber(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (operationSelected) 
            {
                rightOperand += button.Text;
                currentEntry = rightOperand;
            }
            else
            {
                leftOperand += button.Text;
                currentEntry = leftOperand;
            }
            Output_Label.Text = currentEntry;
        }

        private void OnSelectOperator(object sender, EventArgs e)
        {
            var button = (Button)sender;
            operation = button.Text;
            operationSelected = true;
        }

        private void OnClear(object sender, EventArgs e)
        {
            currentEntry = leftOperand = rightOperand = "";
            operation = "";
            operationSelected = false;
            Output_Label.Text = "0";
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            double.TryParse(leftOperand, out double left);
            double.TryParse (rightOperand, out double right);
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = left + right; break;
                case "-":
                    result = left - right; break;
                case "x":
                    result = left * right; break;
                case "/":
                    if(right!= 0 && left!=0)
                    {
                        result = left / right;
                    }
                    else
                    {
                        Output_Label.Text = "Nie dziel przez 0!";
                    }
                    break;
                case "x^2":
                    result = Math.Pow(left, right); break;
                case "SQRT":
                    if(left >=0)
                    {
                        result = Math.Sqrt(left);
                    }
                    break;
            }
            Output_Label.Text = result.ToString();
            leftOperand = result.ToString();
            rightOperand = "";
            operationSelected = false;
        }

    }
}
