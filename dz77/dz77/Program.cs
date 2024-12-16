using System;

namespace ChessProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите позицию белого коня");
            var whiteKnightPosition = Console.ReadLine();

            if (!IsPositionCorrect(whiteKnightPosition))
            {
                Console.WriteLine("Некорректная позиция коня");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите позицию черного ферзя");
            var blackQueenPosition = Console.ReadLine();

            if (!IsPositionCorrect(blackQueenPosition) || whiteKnightPosition == blackQueenPosition)
            {
                Console.WriteLine("Черный ферзь не должен стоять на той же клетке, что и белый конь");
                Console.ReadKey();
                return;
            }

            if (IsQueenStrike(blackQueenPosition, whiteKnightPosition))
            {
                Console.WriteLine("Черный ферзь атакует");
            }
            else
            {
                Console.WriteLine("Черный ферзь не атакует");
                Console.WriteLine("Введите ход белого коня");
                var move = Console.ReadLine();

                if (IsKnightMoveValid(whiteKnightPosition, move))
                    Console.WriteLine("Ход разрешен");
                else
                    Console.WriteLine("Ход запрещен");
            }

            Console.ReadKey();
        }

        static bool IsPositionCorrect(string position)
        {
            if (position.Length != 2)
                return false;

            int row;
            int column;
            DecodePosition(position, out column, out row);
            return column >= 1 && column <= 8 && row >= 1 && row <= 8;
        }

        static bool IsQueenStrike(string blackQueenPosition, string targetPosition)
        {
            int br, bc, tr, tc;
            DecodePosition(blackQueenPosition, out bc, out br);
            DecodePosition(targetPosition, out tc, out tr);
            return bc == tc || br == tr || Math.Abs(bc - tc) == Math.Abs(br - tr);
        }

        static bool IsKnightMoveValid(string startPosition, string movePosition)
        {
            if (!IsPositionCorrect(movePosition))
                return false;

            int startColumn, startRow, moveColumn, moveRow;
            DecodePosition(startPosition, out startColumn, out startRow);
            DecodePosition(movePosition, out moveColumn, out moveRow);
            return (Math.Abs(startColumn - moveColumn) == 1 && Math.Abs(startRow - moveRow) == 2) ||
                   (Math.Abs(startColumn - moveColumn) == 2 && Math.Abs(startRow - moveRow) == 1);
        }

        static void DecodePosition(string position, out int column, out int row)
        {
            row = int.Parse(position[1].ToString());
            column = (int)position[0] - 0x60;
        }
    }
}
