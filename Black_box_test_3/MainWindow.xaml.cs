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

namespace Black_box_test_3
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
        //В данной программе намеренные ошибки прописаны в комментариях со знаком !  (3)

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // ! Отсутствует проверка на ввод отрицательных чисел и чисел равных 0

            answer_label.Content = "";
            var_a.Text = var_a.Text.Trim();
            var_b.Text = var_b.Text.Trim();
            var_c.Text = var_c.Text.Trim();
            try
            {
                double a, b, c;
                string tr_types = "";
                int i = 0;
                

                a = double.Parse(var_a.Text);
                b = double.Parse(var_b.Text);
                c = double.Parse(var_c.Text);
                answer_label.Content = "";

                
                if (a==b && a==c && b==c)
                {
                    tr_types += "Равносторонний";
                    i++;
                }
                // ! Отсутствует проверка для равнобедренного треугольника, если равны стороны а и с
                if ((a == b ||  b == c /*|| c == a*/ ))
                {
                    if (i > 0)
                    {
                        tr_types += ",\n";
                    }
                    tr_types += "Равнобедренный";
                    i++;

                }
                if (a != b && a != c && b != c)
                {
                    if (i > 0)
                    {
                        tr_types += ",\n";
                    }
                    tr_types += "Разносторонний";
                    /*! Отсутствует строка( i++; ) - из-за этого если треугольник разносторонний и прямогугольный, это 
                    будет выводиться сплошным текстом без разделителей*/
                    //i++;

                }
                if ((Math.Pow(a,2) == Math.Pow(b, 2) + Math.Pow(c, 2)) ||
                    (Math.Pow(b, 2) == Math.Pow(a, 2) + Math.Pow(c, 2)) ||
                    (Math.Pow(c, 2) == Math.Pow(b, 2) + Math.Pow(a, 2)))
                {
                    if (i > 0)
                    {
                        tr_types += ",\n";
                    }
                    tr_types += "Прямоугольный";
                    i++;
                }
                
                answer_label.Content = (tr_types);

            }
            catch
            {
                answer_label.Content = "";
                
                var_a.Text = check_vars(var_a.Text);
                var_b.Text = check_vars(var_b.Text);
                var_c.Text = check_vars(var_c.Text);
                MessageBox.Show("Введены неправильнве данные", "Заполните данные верно!");

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
