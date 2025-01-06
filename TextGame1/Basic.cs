using System;
using System.Threading;

namespace text1
{
    class Basic
    {
        public void basic_function()
        {
            while (true)
            {
                var money = Program.player.money;

                Console.WriteLine("현재 창은 숫자만 입력 가능합니다.");
                Console.WriteLine($"현재 돈은 {Program.player.money} 입니다.");
                Console.WriteLine(" ");
                Console.WriteLine("1.돈 벌기");
                Console.WriteLine("2.상점(랜덤박스 구매 가능)");

                int base_number = Console.ReadKey().KeyChar;

                if (base_number == 49)
                {
                    Console.Clear();
                    Thread.Sleep(500);
                    Console.WriteLine($"어서오게! {Program.player.name} 퀴즈를 맞추면 100원 씩 주겠네!");
                    Random random_1 = new Random();
                    int randomValue = random_1.Next(0, 2);
                    switch (randomValue)
                    {
                        case 0:
                            SetQuiz("1 + 1 = ?", "2", 100);
                            break;
                        case 1:
                            SetQuiz("1 x 1 = ?", "1", 100);
                            break;
                        case 2:
                            SetQuiz("9102010 x 0 = ?", "0", 100);
                            break;
                    }
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else if (base_number == 50)
                {
                    Console.Clear();
                    Thread.Sleep(500);
                    Console.WriteLine($"어서오세요! 현재 돈은 {Program.player.money}원 입니다!");
                    Thread.Sleep(500);
                    Console.WriteLine("현재 남아있는 상품은 랜덤 상자 하나 입니다 ( 100원 ) 사시겠습니까? \n(숫자만 입력 가능)");
                    Console.WriteLine("1.산다");
                    Console.WriteLine("2.사지 않는다");
                    int purchase = Console.ReadKey().KeyChar;

                    if (purchase == 49)
                    {
                        if (Program.player.money >= 100)
                        {
                            Console.Clear();
                            Console.WriteLine($"구매 완료 현재 돈은 {Program.player.money -= 100}");
                            Thread.Sleep(500);
                            Random random_2 = new Random();
                            int randomValue = random_2.Next(0, 4);
                            switch (randomValue)
                            {
                                case 0:
                                    Console.WriteLine("상자에서 돈 +200원 이 나왔다! \n운이 좀 좋은데?");
                                    Thread.Sleep(500);
                                    Console.WriteLine($"현재 돈은 {Program.player.money += 200}원 입니다!");
                                    Thread.Sleep(1500);
                                    Console.Clear();
                                    break;
                                case 1:
                                    Console.WriteLine("상자에서 돈이 1000원 나왔다!!!!!! \n이거? 더 하는게 좋을지도?");
                                    Thread.Sleep(500);
                                    Console.WriteLine($"현재 돈은 {Program.player.money += 1000}원 입니다!");
                                    Thread.Sleep(1500);
                                    Console.Clear();
                                    break;
                                case 2:
                                    Console.WriteLine("꽝! \n 돈 날렸네");
                                    Thread.Sleep(500);
                                    Console.WriteLine($"현재 돈은 {Program.player.money}원 입니다!");
                                    Thread.Sleep(1500);
                                    Console.Clear();
                                    break;
                                case 3:
                                    Console.WriteLine("돈 - 1000원 \n하...");
                                    Thread.Sleep(500);
                                    Console.WriteLine($"현재 돈은 {Program.player.money -= 1000}원 입니다!");
                                    Thread.Sleep(1500);
                                    Console.Clear();
                                    break;
                                case 4:
                                    Console.WriteLine("돈 - 300원 \n그만 뽑을까...?");
                                    Thread.Sleep(500);
                                    Console.WriteLine($"현재 돈은 {Program.player.money -= 300}원 입니다!");
                                    Thread.Sleep(1500);
                                    Console.Clear();
                                    break;
                            }
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            Thread.Sleep(500);
                            Console.WriteLine("돈이 부족합니다!");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        
                    }
                   
                    else if (purchase == 50)
                    {
                        Console.Clear();

                    }

                }
            }
        }

        private void SetQuiz(string _quiz, string _result, int _reward)
        {
            Console.WriteLine(_quiz);
            string read = Console.ReadLine();

            if (read == _result)
            {
                Console.WriteLine($"정답입니다. 보상 : {_reward}원");
                Program.player.money += 100;
                Console.WriteLine(Program.player.money);
            }
            else
            {
                Console.WriteLine($"틀렸습니다. 현재 돈 {Program.player.money}원");
            }
        }
    }
}
