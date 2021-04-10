using Data_Structures;

class MainProgram
{
    static void Main()
    {

        /*  ARRAY
         *  
        Dynamic_Array<int> obj = new Dynamic_Array<int>(10);
        obj.Insert(10);
        obj.Insert(13,12);
        obj.Insert(16, 2);
        obj.Insert(17);
        obj.remove(2);
        obj.remove(4);
        Console.WriteLine(obj.ToString());
        */

        /*   LINK LIST
         *   
        LinkedList<int> list = new LinkedList<int>();
        list.FindMiddleNode();
        list.GetKthFromEndUtil(2);
        list.AddFirst(10);
        list.GetKthFromEndUtil(2);
        list.AddFirst(200);
        list.AddLast(40);
        list.AddLast(50);
        list.AddFirst(7);
        list.CreateLoop();
        list.DetectLoop();
        
        Console.WriteLine(list.ToString());
        
        list.DeleteLast();
        list.DeleteFirst();
        list.Contains(70);
        list.IndexOf(10);
        list.IndexOf(30);
        Console.WriteLine(list.ToString());
        */

        /* STRING OPS
         * 
        StringOperations op = new StringOperations();
        op.ReverseString("Cammel");
        Console.WriteLine(op.CheckBalancedExpression("[(1+3)-(a*3)]"));
        */

        /* STACK OPERATIONS
        Stack stk = new Stack();
        stk.Push(10);
        stk.Push(90);
        stk.Pop();
        Console.WriteLine(stk.Peek());
        stk.Push(100);
        stk.Push(-1);
        stk.Push(78);
        Console.WriteLine(stk.Peek());

        for (int i = 0; i < 5; i++)
            stk.Pop();

        */

        DoubleStack ds = new DoubleStack();
        ds.PushStackB(19);
        ds.PushStackB(-1);
        ds.PrintStackA();
        ds.PrintStackB();
        ds.PushStackA(10);
        ds.PushStackB(5);
        ds.PrintStackA();
        ds.PrintStackB();
        ds.IsStackBEmpty();
        ds.IsStackAEmpty();
    }
}

