using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backToTheWhite
{
    class Program
    {
        public static int[,] board = new int[5, 5];
        //게임판 배열을 만듦. 필요한 부분은 [3,3]이지만 가장자리 부분을 누르면 오류가 나기 때문에 테두리를 한 칸씩 만들어준다.

        static int tries = 0;  //시도 횟수

        static bool Game_state = true; //게임의 상태

        static void Main(string[] args)
        {
            Random ran = new Random(); //채워진 네모의 위치를 랜덤으로 정하기 위해 랜덤 함수를 사용한다.
            int white = 0, black = 0;

            Console.WriteLine("*Back To The WHITE* \n\n -게임방법 \n\n 원하는 네모의 좌표를 입력하면 해당 위치의 네모와 함께 \n 상하좌우에 있는 네모들도 뒤집힙니다.\n 모든 네모들이 흰색으로 채워지면 게임이 종료됩니다. \n(게임을 종료하려면 (5,5)의 위치를 입력하세요.)");
            //게임방법 설명.

            gameBoard();
            //게임 첫화면 출력

            while (true)  //사용자가 게임시작
            {
                int w = white, b = black; //돌아갈 때 다시 0으로 만들기 위해서.

                changeBlock();
                //사용자가 원하는 블록의 위치 입력 및 상하좌우 블록 변경한다.


                if (Game_state == false)
                {
                    Console.WriteLine("게임을 종료합니다. \n ");
                    break;
                }

                //사용자 선택 후, 다시 출력.
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (board[i, j] == 1)
                        {
                            Console.Write("■");
                            w++;
                        }
                        else if (board[i, j] == 0)
                        {
                            Console.Write("□");
                            b++;
                        }
                        else
                        {
                            Console.Write("　"); //공백부분 출력
                        }
                    }
                    Console.WriteLine("\n");
                }

                if (w == 9)  //모두 채워진 네모일 때.
                {
                    Console.WriteLine("＼(^◇^)/ ! 성공입니다 ! ＼(^◇^)/    ");
                    Console.WriteLine("\n 시도 횟수 : {0} \n", tries);
                    break;
                }
            }
        }


        static void gameBoard()  //게임의 첫화면 출력부분.
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    board[i, j] = 0;

                    board[j, 0] = -1; //공백부분
                    board[0, j] = -1;
                    board[j, 4] = -1;
                    board[4, j] = -1;
                }
            }

            Random ran = new Random();

            for (int i = 0; i <= ran.Next(6); i++)
            //시작화면에 표시될 채워진 네모 결정 

            {
                //(1,1)~(3,3) 사이에 랜덤하게 채워진 네모가 들어가야 하기때문에 +1을 해준다 .
                int x1 = ran.Next(3) + 1;
                int y1 = ran.Next(3) + 1;

                board[x1, y1] = 1; //채워진 네모 함수 = 1;
            }

            for (int i = 0; i < 5; i++) //시작화면의 보드를 출력한다.
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i, j] == 1)
                    {
                        Console.Write("■");
                    }
                    else if (board[i, j] == 0)
                    {
                        Console.Write("□");
                    }
                    else //공백
                    {
                        Console.Write("　");
                    }
                }
                Console.WriteLine("\n");
            }
        }


        static void changeBlock() //사용자의 입력에 따라 블록을 변경한다.
        {
            Console.Write("선택할 블록의 위치를 입력하세요. \n (블록의 위치는 (1,1)~(3,3)까지입니다.) \n");

            //사용자가 원하는 위치를 입력한다.
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            tries++;


            if (x == 5 && y == 5) //게임종료
            {
                Game_state = false;
            }


            if (x != 5 && y != 5) //선택 블록 변경
            {
                if (board[x, y] == 1)
                {
                    board[x, y] = 0;
                }
                else
                {
                    board[x, y] = 1;
                }

                //블록의 상하좌우블록 변경한다.

                if (board[x - 1, y] == 1) { board[x - 1, y] = 0; }  //왼쪽 블록
                else if (board[x - 1, y] == 0) { board[x - 1, y] = 1; }
                else { board[x - 1, y] = -1; }

                if (board[x + 1, y] == 1) { board[x + 1, y] = 0; } //오른쪽 블록
                else if (board[x + 1, y] == 0) { board[x + 1, y] = 1; }
                else { board[x + 1, y] = -1; }

                if (board[x, y - 1] == 1) { board[x, y - 1] = 0; } //위쪽 블록
                else if (board[x, y - 1] == 0) { board[x, y - 1] = 1; }
                else { board[x, y - 1] = -1; }

                if (board[x, y + 1] == 1) { board[x, y + 1] = 0; } //밑쪽 블록
                else if (board[x, y + 1] == 0) { board[x, y + 1] = 1; }
                else { board[x, y + 1] = -1; }

            }
        }
    }
}