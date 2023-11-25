using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisChallenge.Entities
{
    public class Shape
    {
        public int Width;
        public int Height;
        public int[,] Dots;
        public int Id { get; set; }
        public Color Color { get; set; }

        private int[,] backupDots;
        public void turn()
        {
            /*
             * Salva o backup caso necessite voltar o movimento por falta de espaço
             */

            backupDots = Dots;

            Dots = new int[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Dots[i, j] = backupDots[Height - 1 - j, i];
                }
            }

            var temp = Width;
            Width = Height;
            Height = temp;
        }

            /*
             * Volta o movimento caso, quando a peça é girada, entre em conflito com outra peça ou
             * fora do grid
             */
        public void rollback()
        {
            Dots = backupDots;

            var temp = Width;
            Width = Height;
            Height = temp;
        }
    }

}
