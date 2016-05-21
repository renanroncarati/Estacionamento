using Estacionamento.Negocio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    public class CheckoutCommand : ICommand
    {
        private Car _MyCar;

        public CheckoutCommand(Car mycar)
        {
            _MyCar = mycar;
        }

        public void Run()
        {
            Estacionamento.Remove(_MyCar.Placa);
        }
    }
}
