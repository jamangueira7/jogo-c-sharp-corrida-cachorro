using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorridaDeCachorro
{
    class Apostador
    {
        public string nome;
        public Apostas minhaAposta = new Apostas();
        public int dinheiro;

        public RadioButton meuRadioButton;
        public Label meuLabel;

        public void AtualizarLabels()
        {
            meuRadioButton = new RadioButton();
            meuLabel = new Label();

            //Informa para o radio Butons quanto cada apostador tem
            meuRadioButton.Text = nome + " tem " + dinheiro;
            //Msg feita na classe de aposta é exibida. Essa msg é para informa quanto cada apostador apostou
            meuLabel.Text = minhaAposta.DescricaoAposta();

        }
        public void ZerarApostas()
        {
            //quando a corrida temrina precisamos zerar os valores das apostas, isso é feito na hora de pagar as apostas
            minhaAposta.dinheiro = 0;
        }
        public bool FazerApostas(int dinheiroApostado, int cao)
        {
            //IMPORTANTE: Se não for passado this aqui a aposta não vai saber quem foi que fez a aposta.
            //Se vc instanciar apostador de novo na classe Apostas ele vai criar outro apostador e encher a memoria com
            // instancias. Passando this a variavel apostador que é do tipo Apostador declarada na classe Aposta vai entender
            //que você está se referindo a um instancia ja existente.
            minhaAposta.apostador = this;
            //Para importante lembrar que temos dois controles de dinheiro. O dinheiro que cada apostador tem para apostar
            // e o dinheiro apostado em cada corrida. Na classe Aposta a variavel dinheiro quer dizer dinheiro apostado. Já
            // na classe Apostador dinheiro se refere ao dinheiro que poder ser usado nas apostas.
            minhaAposta.dinheiro = dinheiroApostado;
            //numero do cachorro apostado
            minhaAposta.cao = cao;
            return true;
        }

        public void CobrarApostas(int vencedor)
        {
            //Verificamos qual jogador ganhou e fazemos o pagamento e a cobrança aqui.
            dinheiro += minhaAposta.Pagamento(vencedor);
            //limpa as apostas apos o pagamento
            ZerarApostas();
        }
    }
}
