using Estacionamento.Negocio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    public class CheckinCommand : ICommand
    {
        private Car _MyCar;
        private DateTime _CheckinDate;        
     
        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="meucarro"></param>
        public CheckinCommand(Car mycar)
        {
            _MyCar = mycar;
            _CheckinDate = DateTime.Now;

        }

        public void Run()
        {
            Estacionamento.Add(_MyCar, _CheckinDate);
        }
    }
}
