using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace ConsoleApplication1
{    
    [TestFixture]
    public class ProgramTest
    {
        [Test]
        public void LookForSetOfSizeOneOfAOneDigitNumber_ExpectOneListOfThatNumberReturned()
        {
            var listOfSetsReturned = Program.FindSetsThatSumToTotal(1, 2, 9);

            Assert.AreEqual(listOfSetsReturned.Count, 1);
            Assert.AreEqual(listOfSetsReturned[0], new List<int> { 2 });
        }

        [Test]
        public void LookForSetOfSizeOneOfATwoDigitNumber_ExpectEmptyReturned()
        {
            var listOfSetsReturned = Program.FindSetsThatSumToTotal(1, 12, 9);

            Assert.AreEqual(listOfSetsReturned, Program.EMPTY_LIST);
        }

        [Test]
        public void LookForSetOfSizeGreaterThanOneWhichReturnsOneResult_ExpectOneListReturned()
        {
            var listOfSetsReturned = Program.FindSetsThatSumToTotal(2, 17, 9);

            Assert.AreEqual(listOfSetsReturned.Count, 1);
            Assert.AreEqual(listOfSetsReturned[0].Count, 2);
            Assert.AreEqual(listOfSetsReturned[0].Contains(9), true);
            Assert.AreEqual(listOfSetsReturned[0].Contains(8), true);
        }

        [Test]
        public void LookForSetOfSizeGreaterThanOneWhichReturnsMultipleResults_ExpectCorrectListsReturned()
        {
            var listOfSetsReturned = Program.FindSetsThatSumToTotal(2, 16, 9);

            Assert.AreEqual(listOfSetsReturned.Count, 2);
            
            var firstList = listOfSetsReturned[0];
            var secondList = listOfSetsReturned[1];

            Assert.AreEqual(firstList.Count, 2);
            Assert.AreEqual(secondList.Count, 2);
                        
            Assert.AreEqual(firstList[0] + firstList[1], 16);
            Assert.AreEqual(secondList[0] + secondList[1], 16);
			
            Assert.IsFalse(firstList[0] == secondList[0] && firstList[1] == secondList[1]);
            Assert.IsFalse(firstList[1] == secondList[0] && firstList[0] == secondList[1]);
        }

        [Test]
        public void LookForSetOfSizeGreaterThanOneWhichReturnsNoResults_ExpectEmptyReturned()
        {
            var listOfSetsReturned = Program.FindSetsThatSumToTotal(2, 21, 9);

            Assert.AreEqual(listOfSetsReturned, Program.EMPTY_LIST);
        }

    }
}
