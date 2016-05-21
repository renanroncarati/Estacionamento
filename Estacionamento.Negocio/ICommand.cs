using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    interface ICommand
    {
        /// <summary>
        /// Run the command
        /// </summary>
        void Run();
    }
}
