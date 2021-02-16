using System.Collections.Generic;
using SystemTestingVariant9;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Variant9UnitTesting.Work_4_Unit_Testing
{
    [TestClass]
    public class ListFiltererUnitTests
    {

        [TestMethod]
        public void Test_FilterList()
        {
            
            CollectionAssert.AreEqual
            (
                new List<int>() {14, 15, 252},
                ListFilterer.Filter(new List<int>() { 14, 15, 252 }),
                ""
            );

            CollectionAssert.AreEqual
            (
                new List<int>() { 14, 252 },
                ListFilterer.Filter(new List<int>() { 14, 31, 252 }),
                ""
            );

            CollectionAssert.AreEqual
            (
                new List<int>() { -256, -31, 255, 511 },
                ListFilterer.Filter(new List<int>() { -256, -31, 31, 255, 511 }),
                ""
            );

            CollectionAssert.AreEqual
            (
                new List<int>() { -256, -31, 255, 2047 },
                ListFilterer.Filter(new List<int>() { -256, -31, 31, 255, 2047 }),
                ""
            );
        }
}
}
