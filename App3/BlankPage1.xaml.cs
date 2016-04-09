using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        private bool isDot = false;
        public BlankPage1()
        {
            this.InitializeComponent();
            DisplayProperties.OrientationChanged += abc;
            one_btn.Click += Values_Click;
            two_btn.Click += Values_Click;
            three_btn.Click += Values_Click;
            four_btn.Click += Values_Click;
            five_btn.Click += Values_Click;
            six_btn.Click += Values_Click;
            seven_btn.Click += Values_Click;
            eight_btn.Click += Values_Click;
            nine_btn.Click += Values_Click;
            zero_btn.Click += Values_Click;
            mc_btn.Click += Operations_Click;
            mplus_btn.Click += Operations_Click;
            mminus_btn.Click += Operations_Click;
            mr_btn.Click += Operations_Click;
            c_btn.Click += Operations_Click;
            sign_btn.Click += Operations_Click;
            divide_btn.Click += Operations_Click;
            multiply_btn.Click += Operations_Click;
            minus_btn.Click += Operations_Click;
            add_btn.Click += Operations_Click;
            dot_btn.Click += Operations_Click;
            equal_btn.Click += Equals_Click;
            xsquared_btn.Click += Equals_Click;
            onebyx_btn.Click += Equals_Click;
            sin_btn.Click += Equals_Click;
            cos_btn.Click += Equals_Click;
            tan_btn.Click += Equals_Click;

            // DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public void abc(object sender)
        {
            switch (DisplayProperties.CurrentOrientation)
            {
                case DisplayOrientations.Portrait:
                    Frame.Navigate(typeof(MainPage));
                    break;
                case DisplayOrientations.PortraitFlipped: //goto zwykly
                    Frame.Navigate(typeof(MainPage));
                    break;

            }

        }
        private void Values_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (sender as Button);
            double val = Double.Parse(btn.Content.ToString());
            if (display.Text == "0") display.Text = "";
            display.Text += btn.Content;
            //Calc.setData((int)val);
        }
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (sender as Button);
            string comment = "";
            double result;
            double B = double.Parse(display.Text);
            bool val = Calc.getResult(B, out result, out comment);
            display.Text = result.ToString();
            isDot = false;
        }
        private void Operations_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (sender as Button);
            string op = btn.Content.ToString();
            switch (op)
            {
                case "+":
                    Calc.ExecAddition(double.Parse(display.Text));
                    display.Text = "0";
                    break;
                case "-":
                    Calc.ExecSubstraction(double.Parse(display.Text));
                    display.Text = "0";
                    break;
                case "/":
                    Calc.ExecDivision(double.Parse(display.Text));
                    display.Text = "0";
                    break;
                case "*":
                    Calc.ExecMultiplication(double.Parse(display.Text));
                    display.Text = "0";
                    break;
                case "x²":
                    display.Text = Calc.ExecEscalation(double.Parse(display.Text)).ToString();
                    break;
                case "√":
                    display.Text = Calc.ExecSquareRoot(double.Parse(display.Text)).ToString();
                    break;
                case ".":
                    if (!isDot)
                        display.Text += ".";
                    isDot = true;
                    return;
                    break;
                case "+/-":
                    display.Text = "-" + display.Text;
                    break;
                case "C":
                    display.Text = "0";
                    Calc.reset();
                    break;
                case "MR":
                    display.Text = Calc.MemoryRecall().ToString();
                    break;
                case "MC":
                    Calc.MemoryClear();
                    break;
                case "M+":
                    Calc.MemoryAddTo(double.Parse(display.Text));
                    break;
                case "M-":
                    Calc.MemorySubTo(double.Parse(display.Text));
                    break;
                case "1/x":
                    display.Text = Calc.Invert(double.Parse(display.Text)).ToString();
                    break;
                case "sin":
                    display.Text = Calc.Sinus(double.Parse(display.Text)).ToString();
                    break;
                case "cos":
                    display.Text = Calc.Cosinus(double.Parse(display.Text)).ToString();
                    break;
                case "tan":
                    display.Text = Calc.Tangens(double.Parse(display.Text)).ToString();
                    break;
            }
            isDot = false;

        }
    }
}

