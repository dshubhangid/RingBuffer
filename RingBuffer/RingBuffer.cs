using System;
namespace RingBuffer
{
    /// <summary>
    /// A generic ring-buffer instantiated for a certain type and certain capacity
    /// </summary>
    /// <typeparam name="T">The type of data stored in the buffer</typeparam>
    public class RingBuffer<T>
    {

        private T[] buffer;

        // Insertion always from this end
        private int tail = -1;

        //Always deleteion from this end
        private int head = -1;

        private int size = 0;

        public int Capacity { get { return buffer.Length; } }

        public int Size { get { return size; } }

        // Default capacity is 4.
        public RingBuffer() : this(4) { }

        public RingBuffer(int capacity)
        {
            buffer = new T[capacity];
        }


        /// <summary>
        /// Adds a new element to the buffer. If the buffer is already full, the oldest element shall be overwritten..
        /// </summary>
        /// <param name="elementToAdd">The element to be added.</param>
        public void Put(T elementToAdd)
        {
            //Check if buffer is empty : head and tail points to 0th position
            if (head == -1 && tail == -1)
            {
                head = 0;
                size++;
            }
            else if (((tail + 1) % Capacity) == head)
            {
                //Print oldest element here
                Console.WriteLine("Oldest element dequeued {0}", buffer[head]);
                //buffer is already full, the oldest element shall be overwritten
                //Point head to next element
                head = (head + 1) % Capacity;

            }
            else
            {
                size++;
            }
            //Here set value of rear to rear+1 in circular direction
            tail = (tail + 1) % Capacity;
            buffer[tail] = elementToAdd;

        }

        /// <summary>
        /// Displays buffer elements
        /// </summary>

        public void DisplayElements()
        {
            int i = head;
            if (head == -1 && tail == -1)
            {
                Console.WriteLine("RingBuffer is empty");
            }
            else
            {
                Console.WriteLine("RingBuffer is");

                while (i != tail)
                {
                    Console.WriteLine(buffer[i]);
                    i = (i + 1) % Capacity;
                }
                Console.WriteLine(buffer[i]);
            }
        }

        /// <summary>
        /// Get and remove the oldest element. If the buffer is empty, an exception shall be raised.
        /// </summary>
        /// <returns>The oldest added bufer item.</returns>
        public T Get()
        {
            if (head == -1 && tail == -1)
                throw new InvalidOperationException("Buffer is empty");

            Console.WriteLine("Oldest element removed: {0}", buffer[head]);
            T element = buffer[head];
            if (head == tail)
            {
                head = tail = -1;
                size = 0;
            }
            else
            {
                head = (head + 1) % Capacity;
                size--;
            }
            return element;
        }

        /// <summary>
        /// Displays head tail and capacity of buffer
        /// </summary>
        public String DisplayHeadTailAndSizeOfBuffer()
        {
            return "RingBuffer(size=" + Capacity + ", head=" + head + ", tail=" + tail + ")";
        }
    }
}


