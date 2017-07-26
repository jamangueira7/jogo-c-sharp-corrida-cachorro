using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CorridaDeCachorro
{
    class Apostas
    {
        public int dinheiro;
        public int cao;
        public Apostador apostador;

         public string DescricaoAposta()
         {
            //Retorna um msg para o labels de aposta
            if (apostador != null)
            {
                return apostador.nome + " aposta R$" + dinheiro + " no cachorro #" + cao; 
            }
            else
            {
                return "Sem aposta";
            }
             
         }
        public int Pagamento(int vencedor)
        {
            //Verifica se o cachorro vencedor é igual ao que foi feito a aposta para cada instancia de aposta
            if (vencedor == cao)
            {
                //Caso a aposta vença o valor é pago dobrado
                return dinheiro + dinheiro;
            }
            else
            {
                //Caso perca é retirado o dinheiro apostado
                return - dinheiro;
            }
        }
    }
}
