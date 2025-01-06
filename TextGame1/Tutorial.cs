using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace text1
{
    class Tutorial
    {
        public void Enter_your_name()
        {
            Program.player = new Player("Name", 100);
            Player player = Program.player;
            Console.WriteLine("안녕하세요 저는 튜토리얼을 책임지는");
            Thread.Sleep(1000);
            Console.WriteLine("이 게임의 시스템 입니다.");
            Thread.Sleep(1000);
            Console.WriteLine("시작 하기에 앞 서");
            Thread.Sleep(1000);
            Console.WriteLine("당신의 이름을 적어주세요 \n(영어와 숫자만 사용 가능)");
            player.name = Console.ReadLine();
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine($"당신의 이름은 {player.name} 입니다.");
            Thread.Sleep(800);
            Console.WriteLine("이제 이 게임의 대해 알려드리겠습니다!");
            Thread.Sleep(500);
            Console.WriteLine("이 게임은 간단한 터치(키보드 입력) 등으로 돈을 버는 게임 입니다");
            Thread.Sleep(800);
            Console.WriteLine("그 돈을 사용 하여 상점에서 아이템을 살수 있습니다!");
            Thread.Sleep(800);
            Console.WriteLine($"현재 돈은 {player.money}원 입니다");
            Thread.Sleep(800);
            Console.WriteLine("일단 튜토리얼은 여기 까지 입니다 수고 많으셨습니다!");
            Console.Clear();
        }
    }
}

class Player
{
    public string name;
    public int money;

    public Player(string _name, int _money)
    {
        name = _name;
        money = _money;
    }
}
