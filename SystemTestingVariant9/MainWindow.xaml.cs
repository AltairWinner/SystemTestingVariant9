﻿using System;
using System.Collections.Generic;
using System.Windows;

namespace SystemTestingVariant9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResultTextBlock.Text = "";
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = InputArrayBox.Text;
                //Проверяем ввод
                if (input.Length == 0 || input == null)
                {
                    ResultTextBlock.Text = "Был передан пустой массив.";
                    return;
                }
                if (!ValidateInput(input))
                {
                    ResultTextBlock.Text = "Введенные данные некорректны.";
                    return;
                }

                //Работаем
                List<int> validatedText = new List<int>();
                try
                {
                    validatedText = StringConverter.StringToNumberArray(input);
                }
                catch (OverflowException ex)
                {
                    ResultTextBlock.Text = "Введенные данные некорректны.";
                    return;
                }
                var filteredArray = ListFilterer.Filter(validatedText);
                if (filteredArray.Count == validatedText.Count)
                    ResultTextBlock.Text = "В переданном массиве нет чисел, удовлетворяющих условию.";
                else
                    ResultTextBlock.Text = "Отфильтрованный массив: " + StringConverter.NumberArrayToString(filteredArray);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Во время выполнения программы возникла непредвиденная ошибка.\n\n Информация для разработчиков: " 
                    + $"\n Возникло исключение: {ex.Message}" + $"\n\n {ex.StackTrace}", "Ошибка выполнения программы");
            }
            
        }

        private bool ValidateInput(string input)
        {
            //Первая проверка: в строке должны быть только числа и пробелы, либо минус, если число отрицательное
            foreach (char c in input)
            {
                if ((c < '0' || c > '9') && c != ' ' && c != '-')
                    return false;
            }

            return true;
        }
    }
}