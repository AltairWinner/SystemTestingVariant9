using System;
using System.IO;
using System.Threading;
using System.Windows;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlaUI.Core.AutomationElements;

namespace Variant9UnitTesting.Work_6_System_Testing
{
    [TestClass]
    public class MainWindowTester
    {

        string Path
        {
            get
            {
                string path = Environment.CurrentDirectory;
                path = Directory.GetParent(path).FullName;
                path = Directory.GetParent(path).FullName;
                path = Directory.GetParent(path).FullName;
                path += "\\Work 6 System Testing\\testappfolder\\SystemTestingVariant9WPFApp.exe";
                return path;
            }
        }

        [TestMethod]
        public void Test()
        {
            if (!File.Exists(Path))
            {
                MessageBox.Show(
                    "Для проведения системного тестирования приложения его исполняемый файл должен находиться в папке testappfolder и называться SystemTestingVariant9WPFApp.exe",
                    "Ошибка системного тестирования: исполняемый файл не найден");
                Assert.Fail("Исполняемый файл не найден.");
                throw new FileNotFoundException();
            }

            using (var app = FlaUI.Core.Application.Launch(Path))
            {
                try
                {
                    //TODO: посмотреть документацию
                    var automation = new UIA3Automation();
                    var window = app.GetMainWindow(automation, TimeSpan.FromSeconds(10));

                    //Тест 1 - проверка запуска приложения
                    Assert.IsNotNull(window, "Окно не было запущено.");
                    //Тест 2 - проверка заголовка окна
                    Assert.AreEqual("Вариант 9", window.Title);

                    //Находим нужные нам контролы для дальнейшей работы
                    var textField = window.FindFirstDescendant(cf => cf.ByAutomationId("MainWindow_InputArrayBox"))
                        .AsTextBox();
                    var startButton = window.FindFirstDescendant(cf => cf.ByText("Выполнить")).AsButton();
                    var resultText = window.FindFirstDescendant(cf => cf.ByAutomationId("MainWindow_ResultTextBlock"))
                        .AsTextBox();

                    //3 тест - нажатие кнопки при пустом поле
                    startButton.Click();
                    Thread.Sleep(200);
                    Assert.AreEqual("Был передан пустой массив.", resultText.Text,
                        "Обработка пустого поля ввода неверна.");

                    //4 тест - нажатие кнопки при правильных данных
                    textField.Text = "123 453 127 652";
                    startButton.Click();
                    Thread.Sleep(200);
                    Assert.AreEqual("Отфильтрованный массив: 123 453 652", resultText.Text,
                        "Переданная строка обработана неверно.");

                    //5 тест - нажатие кнопки при верных данных, но при наличии "шума" в виде пробелов
                    textField.Text = "   123    453 127    652    ";
                    startButton.Click();
                    Thread.Sleep(200);
                    Assert.AreEqual("Отфильтрованный массив: 123 453 652", resultText.Text,
                        "Переданная строка обработана неверно. В переданной строке присутствовали пробелы.");

                    //6 тест - введенные данные не содержат подходящих элементов, должно выводиться сообщение.
                    textField.Text = "324 534";
                    startButton.Click();
                    Thread.Sleep(200);
                    Assert.AreEqual("В переданном массиве нет чисел, удовлетворяющих условию.", resultText.Text);

                    //7 тест - введенные данные обработать невозможно из-за ошибок в них
                    textField.Text = "4198649126412963779273 sadfsadfq1qrfhqphf8 sdfsd";
                    startButton.Click();
                    Thread.Sleep(200);
                    Assert.AreEqual("Введенные данные некорректны.", resultText.Text);

                    //8 тест - введенные данные обработать невозможно, но в этот раз в них содержатся только цифры
                    textField.Text = "4198649126412963779273 1251235 1521532";
                    startButton.Click();
                    Thread.Sleep(200);
                    Assert.AreEqual("Введенные данные некорректны.", resultText.Text);

                    //9 тест - введенные данные содержат отрицательные числа
                    textField.Text = "123 -453 127 -652";
                    startButton.Click();
                    Thread.Sleep(200);
                    Assert.AreEqual("Отфильтрованный массив: 123 -453 -652", resultText.Text,
                        "Переданная строка обработана неверно.");


                    //10 тест - Числа не трёхзначные
                    textField.Text = "123 -453 31 -652";
                    startButton.Click();
                    Thread.Sleep(200);
                    Assert.AreEqual("Введенные данные некорректны.", resultText.Text,
                        "Переданная строка обработана неверно.");

                    
                    app.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Во время прохождения тестов возникла непредвиденная ошибка, и тестирование было прервано.\n\n Информация для разработчиков: "
                        + $"\n Возникло исключение: {ex.Message}" + $"\n\n {ex.StackTrace}",
                        "Ошибка выполнения тестирования");
                    app.Close();
                    throw;
                }
            }
        
    }
     
    }
}
