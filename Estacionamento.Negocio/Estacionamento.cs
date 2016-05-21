using Estacionamento.Negocio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    public static class Estacionamento
    {
        private static IDictionary<Car, DateTime> _estacionamento = new Dictionary<Car, DateTime>();

        public static void Add(Car car, DateTime referenceTime)
        {
            _estacionamento.Add(car, referenceTime);
        }

        public static void Remove(string placa)
        {
            Car car = new Car();
            car =_estacionamento.FirstOrDefault(c => c.Key.Placa == placa).Key;

            _estacionamento.Remove(car);
        }

        public static IDictionary<Car, DateTime> ObterCarros()
        {
            return _estacionamento;
        }
    }
}
