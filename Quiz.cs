using System;
using System.Media;
using System.Threading;
using static System.Console;

namespace Quiz
{
    public enum QuizQuestionType //초성퀴즈
    {
        //초성퀴즈
        //동물
        ㄷㅈ = 1,
        ㄱㅇㅈ,
        ㄱㅇㅇ,
        ㅁ,
        ㅅ,
        //개발자,
        ㅊㅎㅈ,
        //음료수
        ㅅㅇㄷ,
        ㅋㄹ,
        ㄱㅌㄹㅇ,
        ㅍㅇㅇㅇㄷ,
        //과자
        ㅇㄹㅇ,
        ㄲㄲㅋ,
        ㅇㄱㅈ,
        ㄱㅂㅊ,
        ㅎㄴㅂㅌㅊ,
        //채소
        ㄷㄱ,
        ㅍㅍㄹㅋ,
        ㅇㅂㅊ,
        ㅅㄱㅊ,
        ㄴㅁ,
    }

    public enum QuizAnswerType //1~10 초성퀴즈 11 ~ 20 퀴즈
    {
        돼지 = 1,
        강아지,
        고양이,
        말,
        소,
        차현준,
        사이다,
        콜라,
        게토레이,
        파워에이드,
        오레오,
        꼬깔콘,
        오감자,
        거북칩,
        허니버터칩,
        당근,
        파프리카,
        양배추,
        시금치,
        나물,
    }

    class Program
    {
        static void Main(string[] args)
        {
            GameManager.Instance.GameDetail();
        }
    }

    class AudioManager : Singleton<AudioManager>
    {
        SoundPlayer m_player = new SoundPlayer();

        public void TruePlay()
        {
            m_player = new SoundPlayer("True.wav");
            m_player.Play();
        }

        public void FalsePlay()
        {
            m_player = new SoundPlayer("False.wav");
            m_player.Play();
        }

        public void WinPlay()
        {
            m_player = new SoundPlayer("Win.wav");
            m_player.Play();
        }

        public void LosePlay()
        {
            m_player = new SoundPlayer("Lose.wav");
            m_player.Play();
        }
    }

    class GameManager : Singleton<GameManager>
    {
        Quiz quiz = new Quiz();
        public void Start()
        {
            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(48, 1);
            WriteLine("\t####################################################");
            SetCursorPosition(48, 2);
            WriteLine("\t#                                                  #");
            SetCursorPosition(48, 3);
            WriteLine("\t#                                                  #");
            SetCursorPosition(48, 4);
            WriteLine("\t#                                                  #");
            SetCursorPosition(48, 5);
            WriteLine("\t#                                                  #");
            SetCursorPosition(48, 6);
            WriteLine("\t#                                                  #");
            SetCursorPosition(48, 7);
            WriteLine("\t#                                                  #");
            SetCursorPosition(48, 8);
            WriteLine("\t#                                                  #");
            SetCursorPosition(48, 9);
            WriteLine("\t#                                                  #");
            SetCursorPosition(48, 10);
            WriteLine("\t####################################################");
            SetCursorPosition(48, 11);
            WriteLine("\t#                                                  #");
            SetCursorPosition(48, 12);
            WriteLine("\t#                                                  #");
            SetCursorPosition(48, 13);
            WriteLine("\t#                                                  #");
            SetCursorPosition(48, 14);
            WriteLine("\t#                                                  #");
            SetCursorPosition(48, 15);
            WriteLine("\t#                                                  #");
            SetCursorPosition(48, 16);
            WriteLine("\t#                                                  #");
            SetCursorPosition(48, 17);
            WriteLine("\t#                                                  #");
            SetCursorPosition(48, 18);
            WriteLine("\t####################################################");

            SetCursorPosition(6, 5);
            WriteLine("\t「초성 퀴즈 게임」");
            SetCursorPosition(6, 8);
            WriteLine("\t규칙");
            SetCursorPosition(6, 7);
            WriteLine("\t10번 맞추면 승리!");
            SetCursorPosition(6, 8);
            WriteLine("\t3번 이상틀릴 시 패배 입니다!");
            SetCursorPosition(6, 9);
            WriteLine("\t10초 안에 못 맞출 시 패배 입니다!");
        }

        public void GameDetail()
        {
            for (int round = 1; round <= 15; round++)
            {
                Start();
                SetCursorPosition(11, 3);
                ForegroundColor = ConsoleColor.White;
                WriteLine($"\t{round}라운드");
                Game();
            }
        }

        public void Game()
        {
            Quiz quiz = new Quiz();
            //Thread thread = new Thread(quiz.Timer);
            //thread.Start();
            quiz.QuizExplanation();
        }
    }

    class Quiz
    {
        QuestionAndAnswer questionAndAnswer = new QuestionAndAnswer();
        int m_timer = 0;
        static int enterCorrectAnswer = 0; //정답
        static int enterWrongAnswer = 0;   //오답
        const int MAX_INDEX = 15;
        //int m_timer = 10;
        public static int[] m_quiz = new int[MAX_INDEX];
        string name;
        string m_player = null;

        public void QuizRandom()
        {
            Random random = new Random();

            for (int i = 0; i < MAX_INDEX; i++)
            {
                bool isOverlap = false;
                m_quiz[i] = random.Next(1, 20 + 1);

                for (int j = 0; j < i; j++)
                {
                    if (m_quiz[i] == m_quiz[j])//중복 됐다면
                    {
                        isOverlap = true;
                        break;
                    }
                }
                if (isOverlap)//중복 됐다면
                {
                    i--;
                }
            }
        }

        public void QuizExplanation()
        {
            QuizRandom();
            Thread soundThread;
            for (int i = 0; i < 1; i++)
            {
                questionAndAnswer.Subject();
                questionAndAnswer.answer = (QuizAnswerType)m_quiz[i];
                name = questionAndAnswer.answer.ToString();
                SetCursorPosition(65, 3);
                WriteLine("\t문제");
                SetCursorPosition(65, 5);
                WriteLine($"\t주제 : {questionAndAnswer.subject}");
                questionAndAnswer.question = (QuizQuestionType)m_quiz[i];
                SetCursorPosition(64, 6);
                WriteLine($"\t{questionAndAnswer.question}");
            }

            while (true)
            {
                SetCursorPosition(60, 12);
                WriteLine("\t플레이어 입력란 답");
                ForegroundColor = ConsoleColor.Yellow;
                SetCursorPosition(64, 14);
                m_player = ReadLine();
                ForegroundColor = ConsoleColor.White;
                break;
            }

            if (m_player == name)
            {
                if (enterCorrectAnswer < 10)
                {
                    soundThread = new Thread(new ThreadStart(AudioManager.Instance.TruePlay));
                    soundThread.Start();
                }
                SetCursorPosition(60, 15);
                ForegroundColor = ConsoleColor.Blue;
                WriteLine("\t정답입니다.\n");
                m_timer = 10;
                enterCorrectAnswer++;

                if (enterCorrectAnswer >= 10)
                {
                    soundThread = new Thread(new ThreadStart(AudioManager.Instance.WinPlay));
                    soundThread.Start();
                    SetCursorPosition(60, 16);
                    WriteLine("\t당신의 승리 입니다!");
                    Thread.Sleep(1000);
                    Clear();
                    ForegroundColor = ConsoleColor.White;
                    Environment.Exit(0);
                }
                Thread.Sleep(500);
                Clear();
            }
            else if (m_player != name)
            {
                if (enterCorrectAnswer < 3)
                {
                    soundThread = new Thread(new ThreadStart(AudioManager.Instance.FalsePlay));
                    soundThread.Start();
                }
                SetCursorPosition(60, 15);
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\t잘못 적었거나 컴퓨터가 지정한 단어 입니다.\n");
                m_timer = 10;
                //thread1.Abort();
                //thread2.Abort();
                enterWrongAnswer++;

                if (enterWrongAnswer >= 3)
                {
                    soundThread = new Thread(new ThreadStart(AudioManager.Instance.LosePlay));
                    soundThread.Start();
                    SetCursorPosition(60, 16);
                    WriteLine("\t당신의 패배 입니다 ㅠㅠ");
                    Thread.Sleep(1000);
                    Clear();
                    ForegroundColor = ConsoleColor.White;
                    Environment.Exit(0);
                }
                ForegroundColor = ConsoleColor.White;
                Thread.Sleep(500);
                Clear();
            }
        }

        public void Timer()
        {
            m_timer = 10;
            for (int i = 0; i < m_timer; m_timer--)
            {
                Thread.Sleep(1000);
            }

            if (m_timer <= 0)
            {
                Clear();
                ForegroundColor = ConsoleColor.White;
                SetCursorPosition(5, 5);
                WriteLine("시간 초과!!!!!!!!!!");
                CursorVisible = false;
                ForegroundColor = ConsoleColor.Black;
                Environment.Exit(0);
            }
        }

        public void TimerOutPut()
        {
            while (true)
            {
                Thread.Sleep(900);
                SetCursorPosition(0, 0);
                WriteLine($"{m_timer}초 남음");
            }
        }

    }
    struct QuestionAndAnswer
    {
        public string subject;
        public QuizQuestionType question;
        public QuizAnswerType answer;

        public void Subject()
        {
            Quiz quiz = new Quiz();
            for (int i = 0; i < 1; i++)
            {
                if (Quiz.m_quiz[i] >= 1 && Quiz.m_quiz[i] <= 5)
                {
                    subject = "동물";
                }
                else if (Quiz.m_quiz[i] >= 7 && Quiz.m_quiz[i] <= 10)
                {
                    subject = "음료수";

                }
                else if (Quiz.m_quiz[i] >= 11 && Quiz.m_quiz[i] <= 15)
                {
                    subject = "과자";

                }
                else if (Quiz.m_quiz[i] >= 16 && Quiz.m_quiz[i] <= 20)
                {
                    subject = "채소";
                }
                else
                {
                    subject = "이게임의 개발자 이름";
                }
            }
        }
    }

    class Singleton<T> where T : class, new()
    {
        private static T m_instance = null;
        public static T Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new T();
                }
                return m_instance;
            }
        }
    }
}
