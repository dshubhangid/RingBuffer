using Microsoft.VisualStudio.TestTools.UnitTesting;
using RingBuffer;
using System;
namespace RingBufferTest
{
    [TestClass]
    public class RingBufferTests
    {

        private int numOfElements = 4;
        /// <summary>
        /// Ensures that buffer size is correctly incremented when items are added.
        /// </summary>
        [TestMethod()]
        public void Check_Size_Of_Buffer_WhileAddingElements()
        {
            RingBuffer<int> _buffer = new RingBuffer<int>(16);
            for (int i = 0; i < numOfElements; i++)
            {
                int _tmp = i;
                _buffer.Put(_tmp);
                Assert.AreEqual(i + 1, _buffer.Size, "Size is correctly incremented.");
            }
        }

        /// <summary>
        /// checks buffer size and capacity when elements added are exactly same as capacity.
        /// </summary>

        [TestMethod()]
        public void Check_Size_And_Capacity_Of_Buffer_WhenBothAreSame()
        {
            RingBuffer<int> _buffer = new RingBuffer<int>();
            for (int i = 0; i < numOfElements; i++)
            {
                int _tmp = i + 1;
                _buffer.Put(_tmp);
            }

            Assert.AreEqual(_buffer.Capacity, _buffer.Size, "Size is equal to number of elements added.");
        }

        /// <summary>
        /// checks buffer size when capacity is different.
        /// </summary>
        [TestMethod()]
        public void Check_Size_And_Capacity_Of_Buffer_WhenTheyAreDifferent()
        {
            RingBuffer<int> _buffer = new RingBuffer<int>(16);
            for (int i = 0; i < numOfElements; i++)
            {
                int _tmp = i;
                _buffer.Put(_tmp);
            }
            Assert.AreNotEqual(_buffer.Capacity, _buffer.Size, "Size is not equal to capacity.");
        }

        /// <summary>
        /// Checks that value returned by Get funtion removes the oldest element.
        /// </summary>
        [TestMethod()]
        public void IsGetReomovingOldestElement()
        {
            RingBuffer<int> _buffer = new RingBuffer<int>(numOfElements);
            for (int i = 0; i < numOfElements; i++)
            {
                _buffer.Put(i);
            }
            _buffer.DisplayElements();
            for (int i = 0; i < numOfElements; i++)
            {
                int _tmp = _buffer.Get();
                Assert.AreEqual(i, _tmp, "get and remove the oldest element");
            }
            _buffer.DisplayElements();
        }


        /// <summary>
        /// Checks whether exception is raised when Get() is called on an empty buffer.
        /// </summary>
        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsExcception_WhenGetCalledOnEmptyBuffer()
        {
            RingBuffer<int> buffer = new RingBuffer<int>();
            int _tmp = buffer.Get();
        }



    }
}

