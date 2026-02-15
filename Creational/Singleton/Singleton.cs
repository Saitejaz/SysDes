using System;
using System.Threading;


// This resembles Same as Java, but We still create bit easily in c# because, static is thread safe.

// public sealed class Singleton
// {
//     private static volatile Singleton instance;
//     private static readonly object _lock = new object();
//     private string data;
//     private Singleton(string data)
//     {
//         this.data = data;
//     }

//     public static Singleton getInstance(string data)
//     {
//         if (instance == null)
//         {
//             lock (_lock)
//             {
//                 if (instance == null)
//                 {
//                     instance = new Singleton(data);
//                 }
//             }
//         }
//         return instance;
//     }

//     public void printData()
//     {
//         Console.WriteLine(data);
//     }
//     public static void Main()
//     {

//     }
// }



// 2nd Way, Easy Way
public sealed class Singleton
{
    private static readonly Lazy<Singleton> instance = new Lazy<Singleton>(
                            () => new Singleton());
    private Singleton()
    {
        Console.WriteLine("Singleton instance is created!");
    }

    public static Singleton Instance => instance.Value;

    public static void Main()
    {
        Console.WriteLine("Before accessing instance");

        var s1 = Singleton.Instance;
        var s2 = Singleton.Instance;

        Console.WriteLine("After accessing instance");
        Console.WriteLine(s1 == s2); // True
    }
}

