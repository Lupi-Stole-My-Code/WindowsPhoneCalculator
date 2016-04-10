using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
            DisplayProperties.OrientationChanged += abc;

            // Przypisanie Eventów
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
            xsquared_btn.Click += Operations_Click;
            onebyx_btn.Click += Operations_Click;
            squareroot_btn.Click += Operations_Click;
            sin_btn.Click += Operations_Click;
            cos_btn.Click += Operations_Click;
            tan_btn.Click += Operations_Click;
        }

        public void abc(object sender)
        {
            switch (DisplayProperties.CurrentOrientation)
            {
                case DisplayOrientations.Portrait:
                case DisplayOrientations.PortraitFlipped: //goto zwykly
                    Frame.Navigate(typeof(MainPage));
                    break;
            }

        }

        private void Values_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (sender as Button);
            if (display.Text == "0" || display.Text=="NaN") display.Text = "";
            display.Text += btn.Content;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (sender as Button);
            string comment = "";
            double result;
            double B = double.Parse(display.Text);
            bool val = Calc.getResult(B, out result, out comment);
            display.Text = result.ToString();
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
                    try
                    {
                        string a = double.Parse(display.Text + ".0").ToString();
                        display.Text += ".";
                    }
                    catch
                    {
                        // do nothing
                    }
                    return;
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
        }
    }
}

