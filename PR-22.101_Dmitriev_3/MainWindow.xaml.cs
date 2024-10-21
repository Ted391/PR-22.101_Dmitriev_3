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

namespace PR_22._101_Dmitriev_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random(); // Создание экземпляра класса Random
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Calculating_Click(object sender, RoutedEventArgs e)
        {
            int N = int.Parse(tb_ArraySize.Text);
            int RangeBegin = int.Parse(tb_RangeBegin.Text);
            int RangeEnd = int.Parse(tb_RangeEnd.Text);

            int[] array = GenerateArray(N, RangeBegin, RangeEnd);

            SortArray(array);

            // Вывод результата
            tbl_Array.Text = string.Join(", ", array);
        }

        private int[] GenerateArray(int n, int RangeBegin, int RangeEnd)
        {
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(RangeBegin, RangeEnd);
            }
            return array;
        }

        private void SortArray(int[] array)
        {
            List<int> evenNumbers = new List<int>(); // Список четных элементов
            List<int> oddNumbers = new List<int>();  // Список нечетных элементов

            // Разделяем массив на четные и нечетные числа
            foreach (int number in array)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
                else
                {
                    oddNumbers.Add(number);
                }
            }

            // Объединяем списки в исходный массив
            evenNumbers.AddRange(oddNumbers);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = evenNumbers[i];
            }
        }
    }
}
