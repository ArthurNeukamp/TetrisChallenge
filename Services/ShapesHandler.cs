using System;
using TetrisChallenge.Commons;
using TetrisChallenge.Entities;

namespace Tetris
{
    static class ShapesHandler
    {
        private static Shape[] shapesArray;
        static ShapesHandler()
        {
            //Cria as peças em um array
            shapesArray = new Shape[]
                {
                    new Shape {
                        Width = 1,
                        Height = 4,
                        Dots = new int[,]
                        {
                            { 1 },
                            { 1 },
                            { 1 },
                            { 1 }
                        },

                        Color = ColorConstants.IBlock,
                        Id = 1
                    },
                    new Shape {

                        Width = 2,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 2, 2 },
                            { 2, 2 }
                        },

                        Color = ColorConstants.OBlock,
                        Id = 2

                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 0, 3, 0 },
                            { 3, 3, 3 }
                        },

                        Color = ColorConstants.TBlock,
                        Id = 3
                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 0, 0, 4 },
                            { 4, 4, 4 }
                        },

                        Color = ColorConstants.LBlock,
                        Id = 4
                    },
                    //new Shape {
                    //    Width = 3,
                    //    Height = 2,
                    //    Dots = new int[,]
                    //    {
                    //        { 4, 0, 0 },
                    //        { 4, 4, 4 }
                    //    },

                    //    Color = ColorConstants.LBlock,
                    //    Id = 4
                    //}, 
                    //new Shape {
                    //    Width = 3,
                    //    Height = 2,
                    //    Dots = new int[,]
                    //    {
                    //        { 5, 5, 0 },
                    //        { 0, 5, 5 }
                    //    },

                    //    Color = ColorConstants.ZBlock,
                    //    Id = 5
                    //},
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 0, 5, 5 },
                            { 5, 5, 0 }
                        },

                        Color = ColorConstants.ZBlock,
                        Id = 5
                    }
                };
        }

        //Gera uma nova peça aleatoriamente
        public static Shape GetRandomShape()
        {
            var shape = shapesArray[new Random().Next(shapesArray.Length)];

            return shape;
        }
    }
}