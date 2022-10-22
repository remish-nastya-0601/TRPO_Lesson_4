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

namespace Black_box_test_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            answer_label.Content = "";
            answer_label_1.Content = "";
            answer_label_2.Content = "";
        }

        //В данной программе намеренные ошибки прописаны в комментариях со знаком !  (4)

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // ! Не проработан вариант, когда Тень 1 и Тень 2 пересекаются
            //обнуление полей, содержащих ответ и проверку
            answer_label.Content = "";

            x1_1.Text = x1_1.Text.Trim();
            x1_2.Text = x1_2.Text.Trim();
            x2_1.Text = x2_1.Text.Trim();
            x2_2.Text = x2_2.Text.Trim();
            x1_3.Text = x1_3.Text.Trim();
            x2_3.Text = x2_3.Text.Trim();
            y1_1.Text = y1_1.Text.Trim();
            y2_1.Text = y2_1.Text.Trim();
            y1_2.Text = y1_2.Text.Trim();
            y2_2.Text = y2_2.Text.Trim();

            try
            {
                double xt1_1, xt1_2, xt2_1, xt2_2, xt1_3, xt2_3, yt1_1, yt1_2, yt2_1, yt2_2, rez, t1, t2;

                xt1_1 = Math.Min(double.Parse(x1_1.Text), double.Parse(x2_1.Text)); // x1 первой тени
                xt2_1 = Math.Max(double.Parse(x1_1.Text), double.Parse(x2_1.Text)); // x2 первой тени

                xt1_2 = Math.Min(double.Parse(x1_2.Text), double.Parse(x2_2.Text)); // x1 второй тени
                xt2_2 = Math.Max(double.Parse(x1_2.Text), double.Parse(x2_2.Text)); // x2 второй тени

                xt1_3 = Math.Min(double.Parse(x1_3.Text), double.Parse(x2_3.Text)); // x1 третьей тени
                xt2_3 = Math.Max(double.Parse(x1_3.Text), double.Parse(x2_3.Text)); // x2 третьей тени

                yt1_1 = Math.Min(double.Parse(y1_1.Text), double.Parse(y2_1.Text)); 
                yt2_1 = Math.Max(double.Parse(y1_1.Text), double.Parse(y2_1.Text));

                yt1_2 = Math.Min(double.Parse(y1_2.Text), double.Parse(y2_2.Text));
                yt2_2 = Math.Max(double.Parse(y1_2.Text), double.Parse(y2_2.Text));

               
                if((peresek(xt1_1, xt2_1, xt1_2, xt2_2) && peresek(xt1_1, xt2_1, xt1_3, xt2_3) ||
                    peresek(xt1_1, xt2_1, xt1_3, xt2_3) && peresek(xt1_2, xt2_2, xt1_3, xt2_3) ||
                    peresek(xt1_1, xt2_1, xt1_2, xt2_2) && peresek(xt1_2, xt2_2, xt1_3, xt2_3))
                    &&
                    peresek(yt1_1, yt2_1, yt1_2, yt2_2))
                {
                    t1 = dlina_teni(Math.Min(Math.Min(xt1_1, xt1_2), xt1_3), Math.Max(Math.Max(xt2_1, xt2_2), xt2_3));
                    t2 = dlina_teni(Math.Min(yt1_1, yt1_2), Math.Max(yt2_1, yt2_2));
                    answer_label.Content = "";
                    answer_label_1.Content = "Длина 1 тени: " + Math.Round(t1, 2);
                    answer_label_2.Content = "Длина 2 тени: " + Math.Round(t2, 2);

                    rez = t1 + t2;
                    // ! Выводится не сумма, а значения подряд
                    answer_label.Content = Math.Round(t1, 2) + Math.Round(t2, 2);
                }
                else
                {
                    if (!(peresek(yt1_1, yt2_1, yt1_2, yt2_2)))
                    {
                        answer_label.Content = "";
                        answer_label_2.Content = "";
                        MessageBox.Show("Не все отрезки тени 2 пересекаются", "Заполните данные верно!");                      
                    }

                     if (!(peresek(xt1_1, xt2_1, xt1_2, xt2_2) && peresek(xt1_1, xt2_1, xt1_3, xt2_3) ||
                        peresek(xt1_1, xt2_1, xt1_3, xt2_3) && peresek(xt1_2, xt2_2, xt1_3, xt2_3) ||
                        peresek(xt1_1, xt2_1, xt1_2, xt2_2) && peresek(xt1_2, xt2_2, xt1_3, xt2_3)))
                    {
                        answer_label.Content = "";
                        answer_label_1.Content = "";
                        MessageBox.Show("Не все отрезки тени 1 пересекаются", "Заполните данные верно!");
                    }
                }
            }
            catch
            {
                // ! Не обнуляется содержимое ячеек со значениями длины каждой тени
                answer_label.Content = "";

                x1_1.Text = check_vars(x1_1.Text);
                x1_2.Text = check_vars(x1_2.Text);
                x2_1.Text = check_vars(x2_1.Text);
                x2_2.Text = check_vars(x2_2.Text);
                MessageBox.Show("Введены неправильнве данные", "Заполните данные верно!");
            }
        }
        public double dlina_teni(double x1, double x2)
        {
            double dl = 0;
            if (x1 > x2)
            {
                dl = x1 - x2;
            }
            else if (x2 > x1)
            {
                dl = x2 - x1;
            }
            // ! Неправильный расчёт длины в случае, если начальное значение равно конечному
            else
            {
                dl = 100;
            }

            return dl;
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

        public bool peresek(double x1, double x2, double y1, double y2)
        {
            if ((x2 < y1) || (x1 > y2))
            {
                return false;
            }
            else return true;

        }

    }
}
