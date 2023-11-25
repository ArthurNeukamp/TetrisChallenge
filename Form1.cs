using System;
using Tetris;
using TetrisChallenge.Commons;
using TetrisChallenge.Entities;
using TetrisChallenge.Services;

namespace TetrisChallenge
{
    public partial class Form1 : Form
    {
        public string Username = "";
        #region Global Variables
        FormEntrada formEntrada;
        Shape currentShape;
        Shape nextShape;
        Bitmap canvasBitmap;
        Graphics canvasGraphics;
        int canvasWidth = 15;
        int canvasHeight = 22;
        int[,] canvasDotArray;
        int dotSize = 30;
        int spacing = 0;

        Bitmap workingBitmap;
        Graphics workingGraphics;
        #endregion

        public Form1(FormEntrada formEntrada)
        {
            this.formEntrada = formEntrada;
            InitializeComponent();
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.BackColor = Color.Transparent;
            btnPlay.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPlay.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.ImageIndex = 0;
            label1.Text = "Score: " + score;
            // label2.Text = "Level: " + score / 10;
            InitializeGridCells();
            currentShape = getRandomShapeWithCenterAligned();
            nextShape = getNextShape();
            timer1.Interval = 500;
        }

        private void InitializeGridCells()
        {
            // Calcula o tamanho total de um quadrado, incluindo o espaçamento
            int totalDotSize = dotSize + spacing;

            // Redimensiona o picture box com base no tamanho do ponto e no tamanho total
            pictureBox1.Width = canvasWidth * totalDotSize;
            pictureBox1.Height = canvasHeight * totalDotSize;

            // Cria um Bitmap com o tamanho do picture box
            canvasBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            canvasGraphics = Graphics.FromImage(canvasBitmap);

            canvasGraphics.FillRectangle(Brushes.LightGray, 0, 0, canvasBitmap.Width, canvasBitmap.Height);

            // Carrega o bitmap no picture box
            pictureBox1.Image = canvasBitmap;

            // Inicializa a matriz de pontos do canvas. Por padrão, todos os elementos são zero
            canvasDotArray = new int[canvasWidth, canvasHeight];

            // Desenha os quadrados com espaçamento
            for (int x = 0; x < canvasWidth; x++)
            {
                for (int y = 0; y < canvasHeight; y++)
                {
                    int xPos = x * totalDotSize;
                    int yPos = y * totalDotSize;

                    canvasGraphics.FillRectangle(Brushes.White, xPos, yPos, dotSize, dotSize);
                    canvasGraphics.DrawRectangle(Pens.Black, xPos, yPos, dotSize, dotSize);
                }
            }
        }

        int currentX;
        int currentY;
        private Shape getRandomShapeWithCenterAligned()
        {
            var shape = ShapesHandler.GetRandomShape();

            currentX = 7;
            currentY = -shape.Height;

            return shape;
        }

        private void updateCanvasDotArrayWithCurrentShape()
        {
            bool isGameOver = false;

            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (currentShape.Dots[j, i] > 0)
                    {
                        isGameOver = checkIfGameOver();

                        if (isGameOver)
                        {
                            break;
                        }
                        canvasDotArray[currentX + i, currentY + j] = currentShape.Id;
                    }
                }
                if (isGameOver)
                {
                    break;
                }
            }
        }

        private bool checkIfGameOver()
        {
            if (currentY < 0)
            {
                timer1.Stop();
                btnPlay.ImageIndex = 0;

                Database.InsertNewRanking(formEntrada.Username, score);

                score = 0;
                label1.Text = "Score: " + score;
                InitializeGridCells();
                currentShape = getRandomShapeWithCenterAligned();
                nextShape = currentShape;
                timer1.Interval = 500;


                DialogResult dialogResult = MessageBox.Show("Deseja jogar novamente?", "GAME OVER", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                }
                else if (dialogResult == DialogResult.No)
                {
                    formEntrada.Show();
                    this.Close();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        //se conseguir mover retorna true
        private bool moveShapeIfPossible(int moveDown = 0, int moveSide = 0)
        {
            var newX = currentX + moveSide;
            var newY = currentY + moveDown;

            // se toca no embaixo ou laterais
            if (newX < 0 || newX + currentShape.Width > canvasWidth
                || newY + currentShape.Height > canvasHeight)
                return false;

            // se toca em outros blocos
            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (newY + j > 0 && canvasDotArray[newX + i, newY + j] > 0 && currentShape.Dots[j, i] > 0)
                        return false;
                }
            }

            currentX = newX;
            currentY = newY;

            drawShape();

            return true;
        }

        private void drawShape()
        {
            workingBitmap = new Bitmap(canvasBitmap);
            workingGraphics = Graphics.FromImage(workingBitmap);

            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (currentShape.Dots[j, i] > 0)
                    {
                        workingGraphics.FillRectangle(new SolidBrush(currentShape.Color), (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                        workingGraphics.DrawRectangle(Pens.Black, (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                    }
                }
            }

            pictureBox1.Image = workingBitmap;
        }

        int score;
        public void clearFilledRowsAndUpdateScore()
        {
            // verifica cada linha
            for (int i = 0; i < canvasHeight; i++)
            {
                int j;
                for (j = canvasWidth - 1; j >= 0; j--)
                {
                    if (canvasDotArray[j, i] == 0)
                        break;
                }

                if (j == -1)
                {

                    score++;
                    label1.Text = "Score: " + score;
                    // label2.Text = "Level: " + score / 10;
                    // increase the speed 
                    timer1.Interval -= 50;

                    // atualiza o array de pontos com base na verificação
                    for (j = 0; j < canvasWidth; j++)
                    {
                        for (int k = i; k > 0; k--)
                        {
                            canvasDotArray[j, k] = canvasDotArray[j, k - 1];
                        }

                        canvasDotArray[j, 0] = 0;
                    }
                }
            }

            //Desenha o painel com base nos valores atualizados do array
            for (int i = 0; i < canvasWidth; i++)
            {
                for (int j = 0; j < canvasHeight; j++)
                {
                    canvasGraphics = Graphics.FromImage(canvasBitmap);

                    canvasGraphics.FillRectangle(Brushes.White, i * dotSize, j * dotSize, dotSize, dotSize);
                    Color color = canvasColorAtribution(canvasDotArray, i, j);

                    canvasGraphics.FillRectangle(
                        canvasDotArray[i, j] > 0 ? new SolidBrush(color) : Brushes.White,
                        i * dotSize, j * dotSize, dotSize, dotSize
                        );
                    canvasGraphics.DrawRectangle(Pens.Black, i * dotSize, j * dotSize, dotSize, dotSize);
                }
            }

            pictureBox1.Image = canvasBitmap;
        }

        public Color canvasColorAtribution(int[,] canvasDot, int i, int j)
        {

            switch (canvasDot[i, j])
            {
                case 0:
                    return Color.White;
                case 1:
                    return ColorConstants.IBlock;
                case 2:
                    return ColorConstants.OBlock;
                case 3:
                    return ColorConstants.TBlock;
                case 4:
                    return ColorConstants.LBlock;
                case 5:
                    return ColorConstants.ZBlock;
                default:
                    return Color.White;
            }
        }

        Bitmap nextShapeBitmap;
        Graphics nextShapeGraphics;
        private Shape getNextShape()
        {
            var shape = getRandomShapeWithCenterAligned();

            // Mostrar o proximo bloco
            nextShapeBitmap = new Bitmap(6 * dotSize, 6 * dotSize);
            nextShapeGraphics = Graphics.FromImage(nextShapeBitmap);

            nextShapeGraphics.FillRectangle(Brushes.White, 0, 0, nextShapeBitmap.Width, nextShapeBitmap.Height);



            var startX = (6 - shape.Width) / 2;
            var startY = (6 - shape.Height) / 2;

            for (int i = 0; i < shape.Height; i++)
            {
                for (int j = 0; j < shape.Width; j++)
                {
                    Color color = canvasColorAtribution(shape.Dots, i, j);
                    nextShapeGraphics.FillRectangle(
                        shape.Dots[i, j] > 0 ? new SolidBrush(color) : Brushes.White,
                        (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize);
                }
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    nextShapeGraphics.DrawRectangle(Pens.Black, i * dotSize, j * dotSize, nextShapeBitmap.Width, nextShapeBitmap.Height);
                }
            }

            pictureBox2.Size = nextShapeBitmap.Size;
            pictureBox2.Image = nextShapeBitmap;

            return shape;
        }
        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            //var verticalMove = 0;
            //var horizontalMove = 0;

            //// calculate the vertical and horizontal move values
            //// based on the key pressed
            //switch (e.KeyCode)
            //{
            //    // move shape left
            //    case Keys.Left:
            //        verticalMove--;
            //        break;

            //    // move shape right
            //    case Keys.Right:
            //        verticalMove++;
            //        break;

            //    // move shape down faster
            //    case Keys.Down:
            //        horizontalMove++;
            //        break;

            //    // rotate the shape clockwise
            //    case Keys.Up:
            //        currentShape.turn();
            //        break;
            //}
            //var isMoveSuccess = moveShapeIfPossible(horizontalMove, verticalMove);

            //// if the player was trying to rotate the shape, but
            //// that move was not possible - rollback the shape
            //if (!isMoveSuccess && e.KeyCode == Keys.Up)
            //    currentShape.rollback();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (btnPlay.ImageIndex == 1)
            {
                var verticalMove = 0;
                var horizontalMove = 0;


                switch (keyData)
                {
                    case Keys.Left:
                        verticalMove--;
                        break;
                    case Keys.Right:
                        verticalMove++;
                        break;
                    case Keys.Down:
                        horizontalMove++;
                        break;
                    case Keys.Up:
                        currentShape.turn();
                        break;
                }
                var isMoveSuccess = moveShapeIfPossible(horizontalMove, verticalMove);


                if (!isMoveSuccess && keyData == Keys.Up)
                    currentShape.rollback();

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var isMoveSuccess = moveShapeIfPossible(moveDown: 1);


            if (!isMoveSuccess)
            {

                canvasBitmap = new Bitmap(workingBitmap);

                updateCanvasDotArrayWithCurrentShape();


                currentShape = nextShape;
                nextShape = getNextShape();

                clearFilledRowsAndUpdateScore();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (btnPlay.ImageIndex == 0)
            {
                timer1.Start();
                btnPlay.ImageIndex = 1;
            }
            else
            {
                timer1.Stop();
                btnPlay.ImageIndex = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblUserName.Text = "Jogador Atual: " + formEntrada.Username;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            formEntrada.Show();
        }
    }
}