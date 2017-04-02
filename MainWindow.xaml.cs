using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Media.Animation;

namespace Calk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string str = "";
        double rez_oper = 0;
        bool komaIsEnter = false;

        oper op = oper.rivne;

        enum oper { pl, min, mnog, dil, proc, pl_min, rivne }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void animation(object sender)
        {
            DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = ((Button)sender).ActualWidth;
            buttonAnimation.To = ((Button)sender).ActualWidth+1;
            buttonAnimation.Duration = TimeSpan.FromSeconds(0.2);
            buttonAnimation.FillBehavior = FillBehavior.Stop;

            DoubleAnimation heightAnimation = new DoubleAnimation();
            heightAnimation.From = ((Button)sender).ActualHeight;
            heightAnimation.To = ((Button)sender).ActualHeight+2;
            heightAnimation.Duration = TimeSpan.FromSeconds(0.2);
            heightAnimation.FillBehavior = FillBehavior.Stop;
            
            ((Button)sender).BeginAnimation(Button.WidthProperty, buttonAnimation);
            ((Button)sender).BeginAnimation(Button.WidthProperty, heightAnimation);

            
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            str += "1";
            rezult.Text = str;
            animation(sender);

        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            str += "2";
            rezult.Text = str;
            animation(sender);
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            str += "3";
            rezult.Text = str;
            animation(sender);
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            str += "4";
            rezult.Text = str;
            animation(sender);
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            str += "5";
            rezult.Text = str;
            animation(sender);
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            str += "6";
            rezult.Text = str;
            animation(sender);
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            str += "7";
            rezult.Text = str;
            animation(sender);
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            str += "8";
            rezult.Text = str;
            animation(sender);
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            str += "9";
            rezult.Text = str;
            animation(sender);
        }

        private void clear_but_Click(object sender, RoutedEventArgs e)
        {
            str = "";
            rez_oper = 0;
            rezult.Text = str;
            komaIsEnter = false;
            animation(sender);
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            str += "0";
            rezult.Text = str;
            animation(sender);
        }

        private void koma_Click(object sender, RoutedEventArgs e)
        {
            if (!komaIsEnter & str !="")
            {
                str += ",";
                rezult.Text = str;
                komaIsEnter = true;
            }
            animation(sender);
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            if (rezult.Text != "")
            {
                rez_oper = Convert.ToDouble(rezult.Text);
                str = "";
                op = oper.pl;
                komaIsEnter = false;
            }
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            if (rezult.Text != "")
            {
                rez_oper = Convert.ToDouble(rezult.Text);
                str = "";
                op = oper.min;
                komaIsEnter = false;
            }
        }

        private void mnog_Click(object sender, RoutedEventArgs e)
        {
            if (rezult.Text != "")
            {
                rez_oper = Convert.ToDouble(rezult.Text);
                str = "";
                op = oper.mnog;
                komaIsEnter = false;
            }
        }

        private void dil_Click(object sender, RoutedEventArgs e)
        {
            if (rezult.Text != "")
            {
                rez_oper = Convert.ToDouble(rezult.Text);
                str = "";
                op = oper.dil;
                komaIsEnter = false;
            }
        }

        private void proc_Click(object sender, RoutedEventArgs e)
        {
            if (rezult.Text != "")
            {
                rez_oper = Convert.ToDouble(rezult.Text);
                str = "";
                op = oper.proc;
                komaIsEnter = false;
            }
        }

        private void znak_Click(object sender, RoutedEventArgs e)
        {
            if (rezult.Text != "")
            {
                rez_oper = Convert.ToDouble(rezult.Text);
                rez_oper *= (-1);
                rezult.Text = rez_oper.ToString();
                str = rezult.Text;
                op = oper.pl_min;
            }
        }

        private void rez_Click(object sender, RoutedEventArgs e)
        {
            if (rezult.Text != "")
            {
                double tmp = Convert.ToDouble(rezult.Text);

                switch (op)
                {
                    case oper.pl:
                        rez_oper += tmp;

                        break;
                    case oper.min:
                        rez_oper -= tmp;

                        break;
                    case oper.dil:
                        if (tmp == 0 | tmp.ToString() == "")
                        {
                            MessageBox.Show("Ділити на ноль не можна");
                            break;
                        }
                        else
                        {
                            rez_oper /= tmp; 
                            break;
                        }

                        
                    case oper.mnog:
                        rez_oper *= tmp;

                        break;
                    case oper.proc:
                        rez_oper = rez_oper * tmp / 100;

                        break;
                }

                Window_rez nw = new Window_rez();
                nw.Owner = this;
                nw.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                animation(sender);

                DoubleAnimation da = new DoubleAnimation();
                da.From = this.Background.Opacity;
                da.To = 0;
                da.Duration = TimeSpan.FromSeconds(3);
                da.FillBehavior = FillBehavior.Stop;
                this.BeginAnimation(Border.OpacityProperty, da);

                string print = "";
                
                if (rez_oper.ToString().Length > 15)
                {
                    print = rez_oper.ToString().Substring(0, 15);
                }
                else 
                {
                    print = rez_oper.ToString();
                }
                rezult.Text = "";

                nw.txt_bl_rez.Text = print;
                
                if (nw.ShowDialog() == false) 
                {
                    rezult.Text = print;
                }
                
                komaIsEnter = false;
                str = "";
                op = oper.rivne;
            }
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
