using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisChallenge.Services;

namespace TetrisChallenge
{
    public partial class FormEntrada : Form
    {
        Form1 form1;
        FormRanking formRanking;
        public string Username = "teste";
        public FormEntrada()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Username = txtUsername.Text;
            form1 = new Form1(this);
            this.Hide();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formRanking = new FormRanking(this);
            formRanking.ShowDialog();
        }
    }
}
