# Introduction.

Suppose you have a very large set of objects (for example, numbers), which we call Pool. The objects in that Pool may be repeating or not appear at all. In other words, there may be a "5" repeated 2 times but the number "10" may not appear and there may be a "123" repeated 900 times.
```` 
Pool example: {1,4,45,23,23,0,1245,2321,5,11,0,78}
```` 

Por otra parte te dan una secuencia de números y tienes que decir si podrías construirla con los objetos (números) que tienes en el Pool. Igual que en el Pool, en la secuencia de números puede haber repeticiones.

```` 
Sequence example: {4,4,5,1,43,21}
```` 

Ordering can not be assumed neither in Pool nor in sequence.

It is about writing a function that receives the Pool and the sequence, and returns true if the sequence could be composed with objects present in the Pool or false if not.
The idea is to make the function/algorithm as efficient as possible and to explain to me in Big-O notation the performance it has for m elements of Pool and n of the sequence.


# Solution.

The best way to solve this exercise is for the data to be stored in a `Dictionary` when the search is performed. Because the execution time of this method is constant O(1), it doesn't matter how much data you have or operations are done. In the code you can see the comparison of doing the same query with a Dictionary and with an array, to demonstrate it you can see two implementations and that in one of the two the performance test fails. And it is a class that comes in the framework so as not to reinvent the wheel.
