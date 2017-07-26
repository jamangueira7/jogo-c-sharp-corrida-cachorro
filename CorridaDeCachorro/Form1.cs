using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorridaDeCachorro
{
    public partial class Form1 : Form
    {
        Apostador[] apostador = new Apostador[3];
        public Form1()
        {            
            InitializeComponent();

            //instanciando os apostadores
            apostador[0] = new Apostador() { nome = "João", dinheiro = 50 };
            apostador[1] = new Apostador() { nome = "Beto", dinheiro = 50 };
            apostador[2] = new Apostador() { nome = "Alfredo", dinheiro = 50 };

            //Informando nos radio buttons dos apostadores, quem eles são e quanto de dinheiro tem
            rb_apostador1.Text = apostador[0].nome + " tem " + apostador[0].dinheiro;
            rb_apostador2.Text = apostador[1].nome + " tem " + apostador[1].dinheiro;
            rb_apostador3.Text = apostador[2].nome + " tem " + apostador[2].dinheiro;
            //Ate haver uma aposta o botão de corre fica desabilitado
            btn_inciar_corrida.Enabled = false;

        }

        private void lbl_sel_cao_Click(object sender, EventArgs e)
        {

        }

        private void btn_apostar_Click(object sender, EventArgs e)
        {
            int x = 0;
            //Verificamos qual é o apostador
            if (rb_apostador1.Checked == true)
            {
                x = 0;
            }
            if (rb_apostador2.Checked == true)
            {
                x = 1;
            }
            if (rb_apostador3.Checked == true)
            {
                x = 2;
            }
            //fazemos a aposta de cada um dos apostadores. Enviamos para o metodo o valor da aposta e o cão apostado
            apostador[x].FazerApostas ((int)numup_dinheiro.Value, (int)numup_cao.Value);
            //Atualiza os labels de apostas
            apostador[0].AtualizarLabels();
            apostador[1].AtualizarLabels();
            apostador[2].AtualizarLabels();
            //jogar o valor atualizado no label de aposta do apostor 
            lbl_apostador1.Text = apostador[0].meuLabel.Text;
            lbl_apostador2.Text = apostador[1].meuLabel.Text;
            lbl_apostador3.Text = apostador[2].meuLabel.Text;

            //Habilita botão de corrida
            btn_inciar_corrida.Enabled = true;
        }

        private void btn_inciar_corrida_Click(object sender, EventArgs e)
        {
            //Quando a corrida se inicia desabiliatmos o botão de apostas
            btn_apostar.Enabled = false;

            //Instancia dos cães
            Cao[] cao = new Cao[4];
            bool existeVencedor = false;
            int vencedor = 1;

            //cao é uma matriz, como existe 4 cães vamos passar a localização das imagens e o tamanho da pista para todos 
            cao[0] = new Cao();
            cao[0].possicaoInicial = pb_cao1.Location.X;
            cao[0].minhaCaixaDeImagem = pb_cao1;
            cao[0].comprimentoPista = pb_pista.Width;

            cao[1] = new Cao();
            cao[1].possicaoInicial = pb_cao2.Location.X;
            cao[1].minhaCaixaDeImagem = pb_cao2;
            cao[1].comprimentoPista = pb_pista.Width;

            cao[2] = new Cao();
            cao[2].possicaoInicial = pb_cao3.Location.X;
            cao[2].minhaCaixaDeImagem = pb_cao3;
            cao[2].comprimentoPista = pb_pista.Width;

            cao[3] = new Cao();
            cao[3].possicaoInicial = pb_cao4.Location.X;
            cao[3].minhaCaixaDeImagem = pb_cao4;
            cao[3].comprimentoPista = pb_pista.Width;

            //Esse looping faz a corrida acontecer enquanto não houver um vencedor
            while (existeVencedor == false)
            {
                //é checado a cada passagem se existe um vencedor
                if (cao[0].Corrida() == false)
                {
                    //Isso indica a velociada dos cão
                    System.Threading.Thread.Sleep(5);
                    //passando o deslocamento da imagem do cachorro para a classe Cao.
                    pb_cao1.Location = cao[0].minhaCaixaDeImagem.Location;
                }
                else
                {
                    //muda o status da corrida e indica qual o cão vencedor
                    existeVencedor = true;
                    vencedor = 1;
                }

                if (cao[1].Corrida() == false)
                {
                    //Isso indica a velociada dos cão
                    System.Threading.Thread.Sleep(5);
                    //passando o deslocamento da imagem do cachorro para a classe Cao.
                    pb_cao2.Location = cao[1].minhaCaixaDeImagem.Location;
                }
                else
                {
                    //muda o status da corrida e indica qual o cão vencedor
                    existeVencedor = true;
                    vencedor = 2;
                }

                if (cao[2].Corrida() == false)
                {
                    //Isso indica a velociada dos cão
                    System.Threading.Thread.Sleep(5);
                    //passando o deslocamento da imagem do cachorro para a classe Cao.
                    pb_cao3.Location = cao[2].minhaCaixaDeImagem.Location;
                }
                else
                {
                    //muda o status da corrida e indica qual o cão vencedor
                    existeVencedor = true;
                    vencedor = 3;
                }


                if (cao[3].Corrida() == false)
                {
                    //Isso indica a velociada dos cão
                    System.Threading.Thread.Sleep(5);
                    //passando o deslocamento da imagem do cachorro para a classe Cao.
                    pb_cao4.Location = cao[3].minhaCaixaDeImagem.Location;
                }
                else
                {
                    //muda o status da corrida e indica qual o cão vencedor
                    existeVencedor = true;
                    vencedor = 4;
                }
            }

            MessageBox.Show("O vencendor foi o cachorro nº" + vencedor, "Resultado...");

           
            //Pagando ou recebendo as apostas
            apostador[0].CobrarApostas(vencedor);
            apostador[1].CobrarApostas(vencedor);
            apostador[2].CobrarApostas(vencedor);

            //Atualizando os valores depois da cobranças das apostas
            apostador[0].AtualizarLabels();
            apostador[1].AtualizarLabels();
            apostador[2].AtualizarLabels();
            
            //Pega o valor atualizado em cima e jogar nas descrições dos radio buttons
            rb_apostador1.Text = apostador[0].meuRadioButton.Text;
            rb_apostador2.Text = apostador[1].meuRadioButton.Text;
            rb_apostador3.Text = apostador[2].meuRadioButton.Text;

            //Coloca os cachorros na posição inicail
            cao[0].VoltarPosicaoInical();
            cao[1].VoltarPosicaoInical();
            cao[2].VoltarPosicaoInical();
            cao[3].VoltarPosicaoInical();

            //Apos a corrida o botão de aposta volta a ser habilitado
            btn_apostar.Enabled = true;
            //Como não tem aposta o botão de corrida fica desabilitado
            btn_inciar_corrida.Enabled = false;
            //Zera os labels de aposta
            zerarLabelsDeAposta();
        }

        public void zerarLabelsDeAposta()
        {
            //Zera os labels de aposta
            lbl_apostador1.Text = "";
            lbl_apostador2.Text = "";
            lbl_apostador3.Text = "";
        }
        private void rb_apostador1_Enter(object sender, EventArgs e)
        {
            //coloca o foco no apostador 1
            rb_apostador1.Focus();
            //Mostra o nome do apostador selecionado no label
            lbl_apostador.Text = apostador[0].nome;
            //Define como aposta maxima o valor em dinheiro que o apostador ainda tem
            numup_dinheiro.Maximum = apostador[0].dinheiro;
        }

        private void rb_apostador2_Enter(object sender, EventArgs e)
        {
            //coloca o foco no apostador 2
            rb_apostador2.Focus();
            //Mostra o nome do apostador selecionado no label
            lbl_apostador.Text = apostador[1].nome;
            //Define como aposta maxima o valor em dinheiro que o apostador ainda tem
            numup_dinheiro.Maximum = apostador[1].dinheiro;
        }

        private void rb_apostador3_Enter(object sender, EventArgs e)
        {
            //coloca o foco no apostador 2
            rb_apostador3.Focus();
            //Mostra o nome do apostador selecionado no label
            lbl_apostador.Text = apostador[2].nome;
            //Define como aposta maxima o valor em dinheiro que o apostador ainda tem
            numup_dinheiro.Maximum = apostador[2].dinheiro;
        }
    }
}
