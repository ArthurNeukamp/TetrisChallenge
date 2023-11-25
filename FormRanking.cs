using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisChallenge.Entities;
using TetrisChallenge.Services;

namespace TetrisChallenge
{
    public partial class FormRanking : Form
    {
        FormEntrada formEntrada;
        List<PlayerRank> ranks;
        public FormRanking(FormEntrada formEntrada)
        {
            InitializeComponent();
            this.formEntrada = formEntrada;
        }

        private void FormRanking_Load(object sender, EventArgs e)
        {
            ranks = new List<PlayerRank>();
            ranks = Database.ObterTop10Pontuacoes();


            lblPlayer1.Text = ranks.Count >= 1 ? ranks[0].Jogador : "";
            lblPlayer2.Text = ranks.Count >= 2 ? ranks[1].Jogador : "";
            lblPlayer3.Text = ranks.Count >= 3 ? ranks[2].Jogador : "";
            lblPlayer4.Text = ranks.Count >= 4 ? ranks[3].Jogador : "";
            lblPlayer5.Text = ranks.Count >= 5 ? ranks[4].Jogador : "";
            lblPlayer6.Text = ranks.Count >= 6 ? ranks[5].Jogador : "";
            lblPlayer7.Text = ranks.Count >= 7 ? ranks[6].Jogador : "";
            lblPlayer8.Text = ranks.Count >= 8 ? ranks[7].Jogador : "";
            lblPlayer9.Text = ranks.Count >= 9 ? ranks[8].Jogador : "";
            lblPlayer10.Text = ranks.Count >= 10 ? ranks[9].Jogador : "";

            lblPontos1.Text = ranks.Count >= 1 ? ranks[0].PontuacaoJogador.ToString() : "";
            lblPontos2.Text = ranks.Count >= 2 ? ranks[1].PontuacaoJogador.ToString() : "";
            lblPontos3.Text = ranks.Count >= 3 ? ranks[2].PontuacaoJogador.ToString() : "";
            lblPontos4.Text = ranks.Count >= 4 ? ranks[3].PontuacaoJogador.ToString() : "";
            lblPontos5.Text = ranks.Count >= 5 ? ranks[4].PontuacaoJogador.ToString() : "";
            lblPontos6.Text = ranks.Count >= 6 ? ranks[5].PontuacaoJogador.ToString() : "";
            lblPontos7.Text = ranks.Count >= 7 ? ranks[6].PontuacaoJogador.ToString() : "";
            lblPontos8.Text = ranks.Count >= 8 ? ranks[7].PontuacaoJogador.ToString() : "";
            lblPontos9.Text = ranks.Count >= 9 ? ranks[8].PontuacaoJogador.ToString() : "";
            lblPontos10.Text = ranks.Count >= 10 ? ranks[9].PontuacaoJogador.ToString() : "";
        }
    }
}
