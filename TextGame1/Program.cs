using System;
using System.Threading;

namespace text1
{
    class Program
    {
        public static Player player = null;
        static void Main(string[] args)
        {
            Start start = new Start();
            start.Starting();
            Tutorial tutorial = new Tutorial();
            tutorial.Enter_your_name();
            Basic basic = new Basic();
            basic.basic_function();

        }
    }
}


