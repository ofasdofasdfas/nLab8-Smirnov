using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LinkedListAverageExample
{
    public partial class MainWindow : Window
    {
        private LinkedList<int> linkedList;

        public MainWindow()
        {
            InitializeComponent();
            linkedList = new LinkedList<int>();
        }

        private void OnCalculateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = txtNumbers.Text.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Введите хотя бы одно число.");
                    return;
                }

                // Разбиваем строку на числа
                string[] numberStrings = input.Split(',');
                List<int> numbers = new List<int>();

                foreach (string numStr in numberStrings)
                {
                    if (int.TryParse(numStr.Trim(), out int num))
                    {
                        numbers.Add(num);
                    }
                    else
                    {
                        MessageBox.Show($"Неверный формат числа '{numStr.Trim()}'. Повторите ввод.");
                        return;
                    }
                }

                // Очищаем предыдущий список и заполняем новыми значениями
                linkedList.Clear();
                foreach (int num in numbers)
                {
                    linkedList.AddLast(num);
                }

                // Вычисляем среднее арифметическое с 5-го элемента до конца
                double average = CalculateAverageFromFifth();
                txtResult.Text = $"Среднее арифметическое с 5-го элемента до конца: {average}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private double CalculateAverageFromFifth()
        {
            if (linkedList.Count < 5)
            {
                return 0;
            }

            LinkedListNode<int> current = linkedList.First;
            int count = 0;
            double sum = 0;

            // Перемещаемся до пятого элемента
            for (int i = 1; i < 5; i++)
            {
                current = current.Next;
            }

            // Считаем среднее арифметическое от текущего элемента до конца
            while (current != null)
            {
                sum += current.Value;
                count++;
                current = current.Next;
            }

            return sum / count;
        }
    }
}
