using System;
using System.Threading;

class Start
{
    public void Starting()
    {
        Console.WriteLine("현재 창은 숫자만 입력 가능합니다.\n\n1.시작하기\n2.끝내기");

        int startnumber = Console.ReadKey().KeyChar;

        if (startnumber == 49)
        {
            Console.Clear();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("로딩중.");
                Thread.Sleep(300);
                Console.WriteLine("로딩중..");
                Thread.Sleep(300);
                Console.WriteLine("로딩중...");
                Thread.Sleep(300);
                Console.Clear();
            }
            Console.WriteLine("로딩 완료!");
            Thread.Sleep(1000);
            Console.Clear();
            for (int a = 0; a < 1; a++)
            {
                Console.WriteLine("게임의 최적화가 완료 되었습니다 \n게임을 불러오겠습니다 (최대 3초)");
                Console.WriteLine(" ");
                Console.WriteLine("로딩중.");
                Thread.Sleep(500);
                Console.WriteLine("로딩중..");
                Thread.Sleep(500);
                Console.WriteLine("로딩중...");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("게임을 불러왔습니다!");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        else if (startnumber == 50)
        {
            Thread.Sleep(500);
            Console.WriteLine("게임을 종료하겠습니다.");
            Environment.Exit(0);
        }

    }
}