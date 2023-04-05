using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeComInterfaces.Services
{
    interface ITaxService // A letra I antes é pra identificar que é uma interface
    {
        public double Tax(double amount);

    }
}
