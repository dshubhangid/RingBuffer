# RingBuffer
This is a ASP.NET Core 5.0 console application using C#. This application is using MS test project for unit testing.

## Application Overview
RingBuffer is c# implementaion of circular buffer data structure.

* RingBuffer is instantiated for certain type, e.g., string,int,.. instances of that type can be put into the buffer.
Ring
* RingBuffer has certain capacity
* RingBuffer has following main functions:

          1. Put: Adds new element to the buffer.If the buffer is already full oldest element shall be overwritten.
          2. Get: Gets the element and Remove oldest element. If the buffer is empty exception shall be raised.
          3. Size: Gets the current size of the buffer (i.e., actual number of elements in the buffer)
          4. Capacity: Gets the capacity which was set when the buffer was instantiated.
