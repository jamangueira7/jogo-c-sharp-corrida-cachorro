using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CorridaDeCachorro
{
    class Cao
    {
        public int possicaoInicial;
        public int comprimentoPista;
        public PictureBox minhaCaixaDeImagem;
        public int posicao = 0;
        public Random meuRandom;

        public bool Corrida()
        {
            meuRandom = new Random();
            //sortei aleatoriamente o vencedor
            posicao = meuRandom.Next(1, 4);
            //Posição da imagem de cada cachorro.
            Point p = minhaCaixaDeImagem.Location;
            //faz o cachorro se mover no eixo X
            p.X += posicao;
            //move a imagem de acordo com deslocamento da posiçao
            minhaCaixaDeImagem.Location = p;
            //Retorna true quando o cachorro chegar no fim da pista
            if (minhaCaixaDeImagem.Location.X >= 571)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void VoltarPosicaoInical()
        {
            //pega a localização de cada cachorro
            Point p = minhaCaixaDeImagem.Location;
            //recoloca a imagem no ponto de partida da corrida
            p.X = 33;
            minhaCaixaDeImagem.Location = p;
        }
    }
}
