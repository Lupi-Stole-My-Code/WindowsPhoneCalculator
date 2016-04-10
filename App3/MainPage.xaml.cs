using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Graphics.Display;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace App3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
            DisplayProperties.OrientationChanged += abc;
            this.NavigationCacheMode = NavigationCacheMode.Required;
            onebtn.Click += Values_Click;
            twobtn.Click += Values_Click;
            threebtn.Click += Values_Click;
            fourbtn.Click += Values_Click;
            fivebtn.Click += Values_Click;
            sixbtn.Click += Values_Click;
            sevenbtn.Click += Values_Click;
            eightbtn.Click += Values_Click;
            ninebtn.Click += Values_Click;
            zero.Click += Values_Click;
            mcbtn.Click += Operations_Click;
            mplusbtn.Click += Operations_Click;
            mminusbtn.Click += Operations_Click;
            mrbtn.Click += Operations_Click;
            cbtn.Click += Operations_Click;
            signbtn.Click += Operations_Click;
            divide.Click += Operations_Click;
            multi.Click += Operations_Click;
            minus.Click += Operations_Click;
            add.Click += Operations_Click;
            dot.Click += Operations_Click;
            equal.Click += Equals_Click;
        }

        public void abc(object sender)
        {
            switch(DisplayProperties.CurrentOrientation)
            {
                case DisplayOrientations.Landscape:
                case DisplayOrientations.LandscapeFlipped: //to samo co w landscape. olac odwrotnosc
                    Frame.Navigate(typeof(BlankPage1));
                    break;  
            }
            
        }
        private void Values_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (sender as Button);
            if (display.Text == "0") display.Text = "";
            display.Text += btn.Content;
            if (!Calc.validateDisplay(display.Text))
            {
                display.Text = "Invalid Data";
                return;
            }
        }
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (!Calc.validateDisplay(display.Text))
            {
                display.Text = "Invalid Data";
                return;
            }
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
            if (!Calc.validateDisplay(display.Text) && op != "C")
            {
                display.Text = "Invalid Data";
                return;
            }
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
