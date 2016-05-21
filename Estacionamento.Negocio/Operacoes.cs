using Estacionamento.Negocio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    /// <summary>
    /// Classe com as operações de um estacionamento.
    /// </summary>
    public sealed class Operacoes
    {
        private const double VALOR_MIN = 5;
        private const int VAGAS_TOTAIS = 15;        
        
        /// <summary>
        /// Retorna todos os carros no estacionamento
        /// </summary>
        public static IDictionary<Car, DateTime> ObterTodosCarros()
        {
            return Estacionamento.ObterCarros();
        }

        /// <summary>
        /// Registra a entrada de um carro no estacionamento.
        /// </summary>
        public static void Checkin(string placa)
        {
            ICommand _checkinCommand;

            //validation
            if (String.Equals(placa.Trim(), string.Empty))
                throw new Exception(String.Format("Placa inválida.", placa));

            if (Estacionamento.ObterCarros().Count == VAGAS_TOTAIS)
                throw new Exception("Estacionamento cheio!");

            if (Estacionamento.ObterCarros().Any(c => c.Key.Placa.Contains(placa)))
                throw new Exception(String.Format("Carro placa '{0} já existe!", placa));

            //TODO: replace this
            Car myCar = new Car();
            myCar.Placa = placa;

            _checkinCommand = new CheckinCommand(myCar);
            _checkinCommand.Run();
        }

        /// <summary>
        /// Registra a saída de um carro do estacionamento.
        /// </summary>
        public static double Checkout(string placa)
        {
            ICommand _checkoutCommand;

            if (String.Equals(placa.Trim(), string.Empty))
                throw new Exception(String.Format("Placa inválida.", placa));

            if (!Estacionamento.ObterCarros().Any(c => c.Key.Placa.Contains(placa)))
                throw new Exception(String.Format("Carro placa '{0}' NÃO existe!", placa));
            
            
            var entrada = Estacionamento.ObterCarros().FirstOrDefault(c => c.Key.Placa.Contains(placa)).Value;

            var valor = CalculaEstacionamento(entrada, DateTime.Now);

            Car myCar = new Car();
            myCar.Placa = placa;

            _checkoutCommand = new CheckoutCommand(myCar);
            _checkoutCommand.Run();            
            
            return valor;
        }

        /// <summary>
        /// Calcula o valor com base no tempo de permanência
        /// </summary>
        private static double CalculaEstacionamento(DateTime entrada, DateTime saida)
        {
            var permanencia = saida.Subtract(entrada);
            return Math.Round((permanencia.TotalMinutes / VALOR_MIN), 2);
        }
    }
}
