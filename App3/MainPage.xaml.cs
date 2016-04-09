using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
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
        private bool isDot = false;
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

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
        public void abc(object sender)
        {
            switch(DisplayProperties.CurrentOrientation)
            {
                case DisplayOrientations.Landscape:
                    Frame.Navigate(typeof(BlankPage1));
                    break;
                case DisplayOrientations.LandscapeFlipped: //to samo co w landscape. olac odwrotnosc
                    Frame.Navigate(typeof(BlankPage1));
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
                    if(!isDot)
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
