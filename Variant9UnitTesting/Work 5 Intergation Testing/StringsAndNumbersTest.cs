using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

using System.Text;
using SystemTestingVariant9;

namespace Variant9UnitTesting.Work_5_Intergation_Testing
{
    [TestClass]
    public class StringsAndNumbersTest
    {

        [TestMethod]
        public void FilterString_Test()
        {
            var input = "123 542 325 31";
            var output = StringConverter.StringToNumberArray(input);
            var result= StringConverter.NumberArrayToString(ListFilterer.Filter(output));

            Assert.AreEqual(result, "123 542 325");

            input = "                    123    542           325 31                ";
            output = StringConverter.StringToNumberArray(input);
            result = StringConverter.NumberArrayToString(ListFilterer.Filter(output));
            Assert.AreEqual(result, "123 542 325");
        }
    }
}
