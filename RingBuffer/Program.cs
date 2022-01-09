using System;

namespace RingBuffer
{
    class Program
    {
        static void Main(string[] args)
        {

            RingBuffer<int> buffer = new RingBuffer<int>();
            buffer.Put(5);
            buffer.Put(6);
            buffer.Put(7);
            buffer.Put(8);
            buffer.Put(9);

            Console.WriteLine(buffer.DisplayHeadTailAndSizeOfBuffer());
            buffer.DisplayElements();
            buffer.Get();
            buffer.Get();
            buffer.Get();
            buffer.Get();

            buffer.DisplayElements();
            //buffer.Capacity;
            Console.WriteLine(buffer.DisplayHeadTailAndSizeOfBuffer());
        }
    }
}

