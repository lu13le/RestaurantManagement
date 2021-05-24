using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data
{
    public interface IDbInitializer
    {
        void Initialize();
    }
}
