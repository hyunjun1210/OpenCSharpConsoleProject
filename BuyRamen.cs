using System;
using System.Threading;

namespace BuyRamen
{
    class Program
    {
        static void Main(string[] args)
        {
            int money = 3000;
            Console.WriteLine($"라면을 사시겠습니까? 현재 소지금은 {money}원 입니다.");
            Console.WriteLine("현재 남은 라면은 \n1.삼양라면\n2.진라면\n3.참께라면\n라면의 숫자를 입력해주세요 (라면의 가격은 1000원 입니다)");
            int 라면번호 = Console.Read();

            if (라면번호 == 49)
            {
                Console.WriteLine("삼양라면을 구매했습니다.");
                Thread.Sleep(500);
                Console.WriteLine($"현재 소지금은 {money-1000}원 입니다.");

            }
            else if (라면번호 == 50)
            {
                Console.WriteLine("진라면을 구매했습니다.");
                Thread.Sleep(500);
                Console.WriteLine($"현재 소지금은 {money - 1000}원 입니다.");
            }
            else if (라면번호 == 51)
            {
                Console.WriteLine("참께라면을 구매했습니다.");
                Thread.Sleep(500);
                Console.WriteLine($"현재 소지금은 {money - 1000}원 입니다.");
            }
        }
    }
}


