using System.Collections.Generic;
using SystemTestingVariant9;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Variant9UnitTesting.Work_4_Unit_Testing
{
    [TestClass]
    public class StringConverterUnitTests
    {
        [TestMethod] 
        public void Test_StringToNumberArray()
        {
            CollectionAssert.AreEqual(new List<int> { 123, 423, 154 }, StringConverter.StringToNumberArray("123 423 154"), "Исходная строка преобразована неверно.");
            CollectionAssert.AreEqual(new List<int> { 123, 423, 154 }, StringConverter.StringToNumberArray("   123 423 154"), "Исходная строка с пробелами в начале преобразована неверно.");
            CollectionAssert.AreEqual(new List<int> { 123, 423, 154 }, StringConverter.StringToNumberArray("123 423 154    "), "Исходная строка с пробелами в конце преобразована неверно.");
            CollectionAssert.AreEqual(new List<int> { 123, 423, 154 }, StringConverter.StringToNumberArray("123      423 154"), "Исходная строка с лишними пробелами в середине преобразована неверно.");
            CollectionAssert.AreEqual(new List<int> { 312, -161, 654, 233, 897, 178, 654 }, StringConverter.StringToNumberArray("312 -161 654 233 897 178 654"), "Исходная строка с отрицательным числом преобразована неверно.");
        }

        [TestMethod]
        public void Test_NumberArrayToString()
        {
            Assert.AreEqual("123 432 165", StringConverter.NumberArrayToString(new List<int> { 123, 432, 165 }), "В результате преобразования получена неверная строка");
            Assert.AreEqual("876 -253 165", StringConverter.NumberArrayToString(new List<int> { 876, -253, 165 }), "В результате преобразования получена неверная строка при использовании отрицательного числа");
        }

        [TestMethod]
        public void Test_NormalizeWhiteSpaceForLoop()
        {
            Assert.AreEqual("23 54 23", StringConverter.NormalizeWhiteSpaceForLoop("23      54 23"), "Строка нормализована неверно, присутствуют лишние пробелы");
            Assert.AreEqual("43 -54 56 51", StringConverter.NormalizeWhiteSpaceForLoop("43     -54  56   51"), "Строка нормализована неверно, присутствуют лишние пробелы");
        }
    }
}
