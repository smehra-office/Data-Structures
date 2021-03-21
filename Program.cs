using Data_Structures;
using System;

class MainProgram
{
    static void Main()
    {
        Dynamic_Array<int> obj = new Dynamic_Array<int>(10);
        obj.Insert(10);
        obj.Insert(13,12);
        obj.Insert(16, 2);
        obj.Insert(17);
        obj.remove(2);
        //obj.remove(4);
        Console.WriteLine(obj.ToString());
    }
}

