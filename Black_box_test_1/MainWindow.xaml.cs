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

namespace Black_box_test_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //В данной программе намеренные ошибки прописаны в комментариях со знаком !  (2)


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //обнуление полей, содержащих ответ и проверку
            answer_label.Content = "";
            check_label.Content = "";
            discr.Content = "";
            var_a.Text = var_a.Text.Trim();
            var_b.Text = var_b.Text.Trim();
            var_c.Text = var_c.Text.Trim();
            try
            {
                double a, b, c, ch1, ch2, x1, x2, x, ch;
                a = double.Parse(var_a.Text);
                b = double.Parse(var_b.Text);
                c = double.Parse(var_c.Text);
                answer_label.Content = "";
                check_label.Content = "";
                discr.Content = "";

                // ! Ошибка в формуле (должно быть    b * b - 4 * a * c)
                double d = b * b + 4 * a * c;

                if (d >0)
                {
                    x1 = (-b + Math.Sqrt(d)) / (2 * a);
                    x2 = (-b - Math.Sqrt(d)) / (2 * a);
                    // ! В ответ оба раза выводится значение x2
                    answer_label.Content = ("x1 = " + Math.Round(x1, 2) + "\nx1 = " + Math.Round(x1, 2));
                    ch1 = a * x1 * x1 + b * x1 + c;
                    ch2 = a * x2 * x2 + b * x2 + c;
                    check_label.Content = ("(x1) = " + Math.Round(ch1, 0) + "\n(x2) = " + Math.Round(ch2, 0));
                    discr.Content = Math.Round(d,2);
                }
                else if (d ==0)
                {
                    x = -b / (2 * a);
                    answer_label.Content = ("x = " + Math.Round(x, 2));
                    ch = a * x * x + b * x + c;
                    check_label.Content = ("(x) = " + Math.Round(ch, 0));
                    discr.Content = Math.Round(d, 2);
                }
                else
                {
                    answer_label.Content = ("Уравнение не имеет корней");
                    check_label.Content = ("Дискриминант меньше 0");
                    discr.Content = Math.Round(d, 2);
                }

            }
            catch
            {
                answer_label.Content = "";
                check_label.Content = "";
                discr.Content = "";
                var_a.Text = check_vars(var_a.Text);
                var_b.Text = check_vars(var_b.Text);
                var_c.Text = check_vars(var_c.Text);
                MessageBox.Show("Введены неправильнве данные","Заполните данные верно!");
                
            }

            

        }
        public string check_vars(string str)
        {
            try
            {
                double p = double.Parse(str);

            }
            catch
            {
                str = "";

            }
            return str;
        }
    }
}
