using System;
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
    }
}
