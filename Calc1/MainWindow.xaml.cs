using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calc1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double temp = 0;
        string operation = "";
        string output = "";

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            DivideByZeroException ex = new DivideByZeroException();

            DIV.Content = "\u00F7";
            SQRT.Content = "\u221A";
        }
        double numOne = 0;
        double numTwo = 0;
        double result = 0;
        string OperationType = "";
        private void Number_Pressed(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            DISPLAY.Text += button.Content.ToString();
        }
        private void FunctionKey_Pressed(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var button_text = button.Content.ToString();
            
            switch (button_text)
            {
                case "+":
                    numOne = double.Parse(DISPLAY.Text);
                    OperationType = "+";
                    ClearDisplay();
                    break;

                case "-":
                    numOne = double.Parse(DISPLAY.Text);
                    OperationType = "-";
                    ClearDisplay();
                    break;

                case "*":
                    numOne = double.Parse(DISPLAY.Text);
                    OperationType = "*";
                    ClearDisplay();
                    break;

                case "÷":
                    numOne = double.Parse(DISPLAY.Text);
                    OperationType = "÷";
                    ClearDisplay();
                    break;

                case "=":
                    numTwo = double.Parse(DISPLAY.Text);    
                    Calculate();
                    DISPLAY.Text = String.Format(result.ToString("F"));
                    break;

                    // History Lister //
                    string HistoryEntry = $"{numOne} {OperationType} {numTwo} = {result}\n";
                    HISTORYList.Items.Insert(0, HistoryEntry);
                    break;

                case "%":
                    numOne = double.Parse(DISPLAY.Text);
                    OperationType = "%";
                    ClearDisplay();
                    HISTORYList.Items.Insert(0, $"√({numOne}) = {result}");
                    break;

                case "√":
                    numOne = double.Parse(DISPLAY.Text);
                    result = Math.Sqrt(numOne);
                    DISPLAY.Text = result.ToString("F");
                    break;

                case "x²":
                    numOne = double.Parse(DISPLAY.Text);
                    result = Math.Pow(numOne, 2);
                    DISPLAY.Text = result.ToString("F");
                    HISTORYList.Items.Insert(0, $"{numOne}² = {result}");
                    break;

                case ".":
                    if (!DISPLAY.Text.Contains("."))
                    {
                        DISPLAY.Text += ".";
                    }
                    break;

                case "⌫":
                    if (DISPLAY.Text.Length > 0)
                    {
                        DISPLAY.Text = DISPLAY.Text.Substring(0, DISPLAY.Text.Length - 1);
                    }
                    break;

                case "C":
                    ClearDisplay();
                    break;
                default:
                    break;
            }

        }
        private void Calculate()
        {
            switch (OperationType)
            {
                case "+":
                    result = numOne + numTwo;
                    break;

                case "-":
                    result = numOne - numTwo;
                    break;

                case "*":
                    result = numOne * numTwo;
                    break;

                case "÷":
                    result = numOne / numTwo;
                    break;

                case "%":
                    result = numOne % numTwo;
                    break;
                default:
                    break;
            }
        }
        private void ClearDisplay()
        {
            DISPLAY.Text = "";
        }
        public Label DisplayLabel { get; set; }


        
    }
}
