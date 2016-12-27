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
using System.IO;
using Microsoft.Win32;

namespace Проектное_задание
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

        public double a, b, s,h;
        public bool a_flag = false;
        public bool b_flag = false;
        public bool n_flag = false;
        public bool done_flag = false;
        public int n;
        public double x;
    
        private void information_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void Author_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Метод Симпсона для численного интегрирования. Воскресенская София, 120441 ");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            string[] arr_read;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            arr_read = File.ReadAllLines(ofd.FileName);
            string[] fd_res_string = arr_read[0].Split('|');
            a = Convert.ToDouble(fd_res_string[0]);
            b = Convert.ToDouble(fd_res_string[1]);
            n = Convert.ToInt16(fd_res_string[2]);
            Otvet.Text = Otvet.Text + "Чтение окончено... " + Environment.NewLine;
            Otvet.Text = Otvet.Text + "А: " + a + Environment.NewLine;
            Otvet.Text = Otvet.Text + "B: " + b + Environment.NewLine;
            Otvet.Text = Otvet.Text + "N: " + n + Environment.NewLine;
            n_flag = true;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            string[] str_res = new string[1];
            str_res[0] = "Результат: " + Convert.ToString(s) + Environment.NewLine;
            File.WriteAllLines(sfd.FileName, str_res);
            Otvet.Text = Otvet.Text + "Запись завершена" + Environment.NewLine;

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            {
                if (textBox.Text == "")
                {
                    Otvet.Text = Otvet.Text + "Введите А" + Environment.NewLine;
                    return;
                }
                if (textBox1.Text == "")
                {
                    Otvet.Text = Otvet.Text + "Введите B" + Environment.NewLine;
                    return;
                }
                if (textBox2.Text == "")
                {
                    Otvet.Text = Otvet.Text + "Введите N" + Environment.NewLine;
                    return;
                }
                if (double.TryParse(textBox.Text, out a) == false)
                {
                    Otvet.Text = Otvet.Text + "А не является допустимым числом" + Environment.NewLine;
                    return;
                }
                else
                {
                    a = Convert.ToDouble(textBox.Text);
                    a_flag = true;
                }
                if (double.TryParse(textBox1.Text, out b) == false)
                {
                    Otvet.Text = Otvet.Text + "B не является допустимым числом" + Environment.NewLine;
                    return;
                }
                else
                {
                    b = Convert.ToDouble(textBox1.Text);
                    b_flag = true;
                }
                if (int.TryParse(textBox1.Text, out n) == false)
                {
                    Otvet.Text = Otvet.Text + "N не является допустимым числом" + Environment.NewLine;
                    return;
                }
                else
                {
                    n = Convert.ToInt16(textBox1.Text);
                    n_flag = true;
                }
                if (n < 2)
                {
                    Otvet.Text = Otvet.Text + "N < 2" + Environment.NewLine;
                    return;
                }
                if (a > b)
                {
                    Otvet.Text = Otvet.Text + "a > b" + Environment.NewLine;
                    return;
                }
                Otvet.Text = Otvet.Text + "Значения зарегестрированны" + Environment.NewLine;
            }

        }

        static double Y(double p)
        {
            return 1 / (1 + p * p);
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

            Otvet.Text = Otvet.Text + "a: " + a + Environment.NewLine;
            Otvet.Text = Otvet.Text + "b: " + b + Environment.NewLine;
            Otvet.Text = Otvet.Text + "n: " + n + Environment.NewLine;
            h = (b - a) / n;
            s = 0; x = a + h;
            while (x < b)
            {
                s = s + 4 * Y(x);
                x = x + h;
                s = s + 2 * Y(x);
                x = x + h;
            }
            s = h / 3 * (s + Y(a) - Y(b));

            Otvet.Text="Интеграл = "+ s;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            a = 0;
            b = 0;
            n = 0;
            while (a == b)
            {
                a = rand.Next(0, 10);
                b = rand.Next(0, 10);
                if (a > b)
                {
                    a = rand.Next(0, 10);
                    b = rand.Next(0, 10);
                }
            }
            n = rand.Next(3, 10);
            Otvet.Text = Otvet.Text + "Генерация окончена: " + Environment.NewLine;
            Otvet.Text = Otvet.Text + "А: " + a + Environment.NewLine;
            Otvet.Text = Otvet.Text + "B: " + b + Environment.NewLine;
            Otvet.Text = Otvet.Text + "N: " + n + Environment.NewLine;
            n_flag = true;

        }
        }
    }

